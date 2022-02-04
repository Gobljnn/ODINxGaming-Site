using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Data;
using OdinXSiteMVC2.Models.Roles;
using OdinXSiteMVC2.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace OdinXSiteMVC2.Controllers
{

    //[Authorize(Roles = "Master, Admin")]
    public class RolesController : Controller
    {
        

        private readonly ApplicationDbContext _authDb;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly OdinXSiteMVC2Context _mySqlDb;
        //private readonly Mapper _mapper = new Mapper();

        public RolesController(ApplicationDbContext authDb, RoleManager<IdentityRole> roleManager, OdinXSiteMVC2Context mySqlDb) {
            _authDb = authDb;
            _roleManager = roleManager;
            _mySqlDb = mySqlDb;
        }

        string roleId = "";
        string roleName = "";
        string userName = "";



        // GET: Roles
        public async Task<IActionResult> Index()
        {

            //return View(await _mySqlDb.NewReg.ToListAsync());
            return View(await _mySqlDb.Roles.ToListAsync());

        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _mySqlDb.NewReg.FirstOrDefaultAsync(m => m.Id == id);
            //FindAsync(id);
            //.FirstOrDefaultAsync(m => m.roleID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("roleID,roleName")] Role roles)
        {
            if (ModelState.IsValid)
            {
               //UPON POST ROLE NAME FROM INDEX IS TAKEN AND USED TO CREATE A NEW ROLE
                await _roleManager.CreateAsync(new IdentityRole(roles.roleName));
                await _authDb.SaveChangesAsync();

                //ADD TO PERSONAL DBS
                //_authDb.Roles.Add(roles);

                //NEW ENTITY TO COPY INFO
                Role newRole = _roleManager.Roles
                    .Where(p => p.Name.Equals(roles.roleName))
                    .Select(rid => new Role { roleID = rid.Id })
                    .FirstOrDefault();

                roles.roleID = newRole.roleID;
                
                //ADD NEW ROLE TO ROLES REPO - FOR EDITING
                _mySqlDb.Roles.Add(roles);

                await _mySqlDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(string id) //ID in is user ID
        {
            //initialize the user variable
            var user = await _mySqlDb.NewReg.FirstOrDefaultAsync(m => m.Id == id);



            userName = user.userName;
            ViewData["userName"] = userName;

            //Get role id from mysql new reg table
            roleId = user.roleId;
            ViewData["roleId"] = roleId;



            //Go to roles tables in auth db find the role gotten from the roleId returns obj
            var role = await _roleManager.FindByIdAsync(roleId);


            //iterate through roles table in dba (rolemanager) and get all roles names
            var allRoles = _roleManager.Roles.ToList();
  
            //var model = new RoleDTO();
            //model.roleName = allRoles
            //    .Select(x => x.Name)
            //    .ToString();

            //Send data to view
            ViewData["allRoles"] = allRoles;
            //ViewData["allRoles"] = new SelectList(allRoles, "Id", "Name");
            ViewData["allRoles"] = new SelectList(allRoles, "Id", "Name");


            /*viewbag in ASP.NET MVC is used to transfer temporary data
            (which is not included in the model) from the controller to the view. 
            ID is going to be returned to the backend and roles will be presented
            to the user*/


            if (id == null || role == null)
            {
                return NotFound();
            }

            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("roleID,roleName")] Role roles, [Bind("firstName,lastName,userName,profilePic,gamerTag,role,roleId")] NewRegDTO newReg)
        {
            var user = await _mySqlDb.NewReg.FirstOrDefaultAsync(m => m.Id == id);
            roleId = roles.roleID;

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role.Id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _authDb.Update(roles);
                    await _authDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesExists(roles.roleID))
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
            return View();
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var user = await _authDb.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _authDb.Users.FindAsync(id);
            _authDb.Users.Remove(user);
            await _authDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesExists(string id)
        {
            return _authDb.Roles.Any(e => e.roleID == id);
        }
    }
}
