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
        private readonly UserManager<ApplicationUser> _authDb;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly OdinXSiteMVC2Context _mySqlDb;

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
                        IWebHostEnvironment webhost,OdinXSiteMVC2Context mySqlDb){
            _authDb = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webhost;
            //_mySqlDb = mySqlDb;
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
            var userName = await _authDb.GetUserNameAsync(user);
            var phoneNumber = await _authDb.GetPhoneNumberAsync(user);
            var bio = user.bio;

            Username = userName;

            Input = new InputModel {
                PhoneNumber = phoneNumber,
                Bio = bio,
               
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _authDb.GetUserAsync(User);
            
            //CANNOT FIND USER
            if (user == null) {
                //return NotFound($"Unable to load user with ID '{_authDb.GetUserId(User)}'.");
            }

            //IF USER FOUND
            //CREATE VAR OF USER REPO
            var userrepo = "user_" + user.Id.Substring(0, 5) + "X_";

            //DEFAULT PATH FOR DEFAULT PROFILE PIC
            var def = "../../Assets/Pic/defaultPic.jpg";

            //PATH FOR PERSONAL PROFILE PIC
            if ( (user.profilePic == null) ) {
                
                ViewData["ID"] = def;
            }
            else if (user.profilePic.Equals(def)) {
                ViewData["ID"] = def;
            }
            else {
                ViewData["ID"] = user.profilePic;
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile imageFile, UserImage userImage) {
            var user = await _authDb.GetUserAsync(User);

            //CANNOT FIND USER
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_authDb.GetUserId(User)}'.");
            }

            //IF ALL INPUTS ARE FINE
            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _authDb.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _authDb.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var bio = user.bio;
            if (Input.Bio != bio) {
                user.bio = Input.Bio;
                await _authDb.UpdateAsync(user);
            }

            await _authDb.UpdateAsync(user);


            //IF YOU WANT TO SAVE PIC DIRECTLY TO DB - LAST RESORT - REMOVE  - AT A LATER DATE#GOB
            /*                IFormFile file = Request.Form.Files.FirstOrDefault();
                            using (var dataStream = new MemoryStream()) {
                                await file.CopyToAsync(dataStream);
                                user.profilePic = dataStream.ToArray();
                            }

                            await _authDb.UpdateAsync(user);*/

            //AS LONG AS IMAGE ISN'T BLANK
            if (imageFile != null) {

                //get the extension of the user uploaded file
                string ext = Path.GetExtension(imageFile.FileName);
                var id = "user_" + user.Id.Substring(0, 5) + "X_";
                var picname = imageFile.FileName;

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
                    //var saveimg = Path.Combine(pathString, "ProfilePhoto" + ext);
                    var saveimg = Path.Combine(pathString, picname);


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
                        //user.profilePic = "../../unver_images/" + id + "/ProfilePhoto" + ext;
                        user.profilePic = "../../unver_images/" + id + "/"+ picname;


                        //USER ID - REMOVE  - AT A LATER DATE#GOB
                        //userImage.userID = user.Id.Substring(0, 5);
                        userImage.userID = user.Id;

                        // add and db save
                        await _authDb.UpdateAsync(user);

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
