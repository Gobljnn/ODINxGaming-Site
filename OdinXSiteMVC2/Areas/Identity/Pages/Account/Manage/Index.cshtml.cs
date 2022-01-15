using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var bio = user.bio;

            Username = userName;

            Input = new InputModel {
                PhoneNumber = phoneNumber,
                Bio = bio,
               
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);    
            
            //CANNOT FIND USER
            if (user == null) {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //IF USER FOUND
            //CREATE VAR OF USER REPO
            var userrepo = "user_" + user.Id.Substring(0, 5) + "X_";

            //USING LAMBDA EXPRESSION FIND USER FROM PERSONAL DB THAT HAS THE SAME USER ID AS AUTHENTICATION DB
            NewRegDTO myUser = _context.NewReg
                .Where(p => p.Id.Equals(user.Id))
                .Select(imgs => new NewRegDTO {  profilePic = imgs.profilePic})
                .FirstOrDefault();

            //DEFAULT PATH FOR DEFAULT PROFILE PIC
            var def = "../../Assets/Pic/26293.jpg";

            //PATH FOR PERSONAL PROFILE PIC
            if (myUser.profilePic.Equals(def)) {
                
                ViewData["ID"] = def;
            }
            else {
                ViewData["ID"] = myUser.profilePic;
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile imageFile, UserImage userImage) {
            var user = await _userManager.GetUserAsync(User);

            //FIND USER IN PERSONAL DB THAT MATCHES AUTHEN ID
            var myUser = _context.NewReg
                .Where(p => p.Id == user.Id)
                .FirstOrDefault();

            //CANNOT FIND USER
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //IF ALL INPUTS ARE FINE
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


            //IF YOU WANT TO SAVE PIC DIRECTLY TO DB - LAST RESORT - REMOVE  - AT A LATER DATE#GOB
            /*                IFormFile file = Request.Form.Files.FirstOrDefault();
                            using (var dataStream = new MemoryStream()) {
                                await file.CopyToAsync(dataStream);
                                user.profilePic = dataStream.ToArray();
                            }

                            await _userManager.UpdateAsync(user);*/

            //AS LONG AS EMAIL ISN'T BLANK
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

                        //UPDATE VIEW ID FOR PROFILE PIC CHANGE IN HTML
                        ViewData["ID"] = saveimg;

                        // name and path of file respectively put into personal db
                        //USERIMAGE IS BRIDGE FILE SAVE -
                        userImage.imageName = "Profile Pic";

                        //SAVE NEW PATH
                        userImage.imagePath = saveimg;
                        
                        //CHANGE PROFILE PIC SOURCE IN PERSONAL DB
                        myUser.profilePic = "../../unver_images/" + id + "/ProfilePhoto" + ext;

                        //USER ID - REMOVE  - AT A LATER DATE#GOB
                        userImage.userID = user.Id.Substring(0, 5);

                        // add and db save
                        await _context.UserFiles.AddAsync(userImage);
                        

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
