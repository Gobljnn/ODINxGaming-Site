using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using OdinXSiteMVC2.Data;
using OdinXSiteMVC2.Models;
using OdinXSiteMVC2.Models.DTO;
using OdinXSiteMVC2.Models.Roles;

namespace OdinXSiteMVC2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    //[Authorize(Roles = "Plebs")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly OdinXSiteMVC2Context _mySqlDb;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            OdinXSiteMVC2Context context,
            RoleManager<IdentityRole> roleManager
            )
            
            
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _mySqlDb = context;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string firstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string lastName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "User name")]
            public string userName { get; set; } 
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ViewData["roles"] = _roleManager.Roles.ToList();
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {

                //create entities for db insertion
                var user = new ApplicationUser { UserName = Input.userName, Email = Input.Email, firstName=Input.firstName, lastName=Input.lastName };
                

                //copy only id, name and username to personal db
                var newreg = new NewRegDTO {
                    firstName = Input.firstName,
                    userName = Input.userName,
                    lastName = Input.lastName,
                    email = Input.Email,
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    

                    //add Indentity created items to personal db
                    newreg.Id = user.Id;
                    newreg.profilePic = "../../Assets/Pic/26293.jpg";



                    //ADD NEW USER TO A SPECIFIC ROLE
                    _userManager.AddToRoleAsync(user, "Plebs").Wait();

                    //capture id and role name in  new entity
                    //FIND PLEBS ID
                    Role newRole = _roleManager.Roles
                    .Where(p => p.Name.Equals("Plebs"))
                    .Select(rid => new Role { roleID = rid.Id })
                    .FirstOrDefault();

                    //ADD NEW DATA TO NEWREGDTO
                    newreg.role = "Plebs";
                    newreg.roleId = newRole.roleID;


                    //ADD NEW  USER TO TO PERSONAL DB
                    _mySqlDb.NewReg.Add(newreg);
                    
                    _mySqlDb.SaveChanges();

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        //GO TO MANAGE PAGE UPON REGISTRATION TO ADD PROFILE PIC AND BIO
                        return Redirect("~/Identity/Account/Manage");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
