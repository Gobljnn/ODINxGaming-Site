using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdinXSiteMVC2.Data;
using OdinXSiteMVC2.Models;
using OdinXSiteMVC2.Models.DTO;

namespace OdinXSiteMVC2.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly OdinXSiteMVC2Context _context;

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
                        IWebHostEnvironment webhost,OdinXSiteMVC2Context context){
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webhost;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [DataType(DataType.Text)]
            [MaxLength(300)]
            [Display(Name = "Bio")]
            public string Bio { get; set; }
            //[Display(Name = "Profile Picture")]
            //public string ProfilePic { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var bio = user.bio;
            //var profilePic = user.profilePic;

            Username = userName;

            Input = new InputModel {
                PhoneNumber = phoneNumber,
                Bio = bio,
                //ProfilePic = profilePic
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            //var id = await _userManager.GetUserIdAsync()
            if (user == null) {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userrepo = "user_" + user.Id.Substring(0, 5) + "X_";
            var wwwpath = Path.Combine(_webHostEnvironment.WebRootPath, "unver_images", userrepo,"4.jpg");
            NewRegDTO myUser = _context.NewReg
                .Where(p => p.Id.Equals(user.Id))
                .Select(imgs => new NewRegDTO {  profilePic = imgs.profilePic})
                .FirstOrDefault();
            var def = "../../Assets/Pic/26293.jpg";
            var path = "../../unver_images/";
            var userpic = path + "user_" + user.Id.Substring(0, 5) + "X_/4.jpg";

            if (myUser.profilePic.Equals(def)) {
                
                ViewData["ID"] = "../../Assets/Pic/26293.jpg";
            }
            else {
                ViewData["ID"] = myUser.profilePic;
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile imageFile, UserImage userImage, NewRegDTO newReg) {
            var user = await _userManager.GetUserAsync(User);
            var myUser = _context.NewReg
                .Where(p => p.Id == user.Id)
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var bio = user.bio;
            if (Input.Bio != bio) {
                user.bio = Input.Bio;
                await _userManager.UpdateAsync(user);
            }

            await _userManager.UpdateAsync(user);

            //to save pic to db
            /*                IFormFile file = Request.Form.Files.FirstOrDefault();
                            using (var dataStream = new MemoryStream()) {
                                await file.CopyToAsync(dataStream);
                                user.profilePic = dataStream.ToArray();
                            }

                            await _userManager.UpdateAsync(user);*/

            if (imageFile != null) {
                //get the extension of the user uploaded file
                string ext = Path.GetExtension(imageFile.FileName);
                var id = "user_" + user.Id.Substring(0, 5) + "X_";


                //jpg, jpeg, png, gif allowed
                if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".jif") {

                    //Create a new path (in root folder) for the new user if folder does not exist

                    //folder in wwwroor/unver_imgs
                    var folderName = Path.Combine(_webHostEnvironment.WebRootPath, "unver_images");

                    //combine folder name to user_IDX_ and then create directory if it doesnt exist
                    var pathString = Path.Combine(folderName, id);

                    if (!Directory.Exists(pathString)) {
                        Directory.CreateDirectory(pathString);
                    }

                    //save file in user folder name and save in root with new name.
                    var saveimg = Path.Combine(pathString, "ProfilePhoto" + ext);

                    //create the file
                    using (var uploadingimg = new FileStream(saveimg, FileMode.Create)) {
                        await imageFile.CopyToAsync(uploadingimg);
                        ViewData["ID"] = saveimg;


                        // name and path of file respectively put into personal db
                        userImage.imageName = "Profile Pic";
                        userImage.imagePath = saveimg;
                        myUser.profilePic = "../../unver_images/" + id + "/ProfilePhoto" + ext;
                        //await _context.UpdateAsync(myUser);
                        userImage.userID = user.Id.Substring(0, 5);

                        //    add and db save
                        await _context.UserFiles.AddAsync(userImage);
                        //await _context.NewReg.AddAsync(newReg)

                        await _context.SaveChangesAsync();
                        ViewData["Message"] = "The Selected File " + imageFile.FileName + " has been saved ";
                    }
                }

                else {
                    ViewData["Message"] = "The Selected File " + imageFile.FileName + " did not save. Check the image file type (only JPG, JPEG, GIF, PNG allowed  ";
                }

            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
                return RedirectToPage();
        }

    }
}
