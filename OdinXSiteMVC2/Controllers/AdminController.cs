using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Data;
using OdinXSiteMVC2.Models.Admin;

namespace OdinXSiteMVC2.Controllers
{
    public class AdminController : Controller
    {
        private readonly OdinXSiteMVC2Context _mySqlDb;
        private readonly ApplicationDbContext _authDb;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(OdinXSiteMVC2Context mySqlDb, ApplicationDbContext authDb, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _mySqlDb = mySqlDb;
            _authDb = authDb;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: AdminEdits
        public async Task<IActionResult> Index()
        {
            var members = _authDb.Users;
            return View(await members.ToListAsync());
        }

        // GET: AdminEdits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminEdit = await _authDb.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminEdit == null)
            {
                return NotFound();
            }

            return View(adminEdit);
        }

        // GET: AdminEdits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminEdits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        //bind has to exactly match the variable in model
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,UserName,gamerTag,bio,execBio,profilePic,execPic")] ApplicationUser adminEdit) 
        {
            if (ModelState.IsValid)
            {
                var createUser = new ApplicationUser {
                    firstName = adminEdit.firstName,
                    lastName = adminEdit.lastName,
                    UserName = adminEdit.UserName,
                    gamerTag = adminEdit.gamerTag,
                    bio = adminEdit.bio,
                    execBio = adminEdit.execBio,
                    profilePic = adminEdit.profilePic,
                    execPic = adminEdit.execPic
                };

                await _userManager.CreateAsync(createUser);
                _authDb.Add(adminEdit);
                await _authDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminEdit);
        }

        // GET: AdminEdits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminEdit = await _authDb.Users.FindAsync(id);
            if (adminEdit == null)
            {
                return NotFound();
            }
            return View(adminEdit);
        }

        // POST: AdminEdits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,firstName,lastName,UserName,gamerTag,bio,execBio,profilePic,execPic")] ApplicationUser adminEdit)
        {
            //create an object for the current user to Edit
            var user = await _userManager.FindByIdAsync(id);

            //create new edit object with Application user as its model
            var editUser = new ApplicationUser {
                firstName = adminEdit.firstName,
                lastName = adminEdit.lastName,
                UserName = adminEdit.UserName,
                gamerTag = adminEdit.gamerTag,
                bio = adminEdit.bio,
                execBio = adminEdit.execBio,
                profilePic = adminEdit.profilePic,
                execPic = adminEdit.execPic
            };

            //change user with new updated info
            user.firstName = editUser.firstName;
            user.lastName = adminEdit.lastName;
            user.UserName = adminEdit.UserName;
            user.gamerTag = adminEdit.gamerTag;
            user.bio = adminEdit.bio;
            user.execBio = adminEdit.execBio;
            user.profilePic = adminEdit.profilePic;
            user.execPic = adminEdit.execPic;

            if (id != adminEdit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    //update the database using userManager
                    await _userManager.UpdateAsync(user);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminEditExists(adminEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adminEdit);
        }

        // GET: AdminEdits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminEdit = await _authDb.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminEdit == null)
            {
                return NotFound();
            }

            return View(adminEdit);
        }

        // POST: AdminEdits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var adminEdit = await _authDb.Users.FindAsync(id);
            _authDb.Users.Remove(adminEdit);
            await _authDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminEditExists(string id)
        {
            return _authDb.AdminEdit.Any(e => e.Id == id);
        }
    }
}
