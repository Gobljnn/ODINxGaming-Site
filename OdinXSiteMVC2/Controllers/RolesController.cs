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

namespace OdinXSiteMVC2.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _authDb;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly OdinXSiteMVC2Context _mySqlDb;

        public RolesController(ApplicationDbContext authDb, RoleManager<IdentityRole> roleManager, OdinXSiteMVC2Context mySqlDb) {
            _authDb = authDb;

            _roleManager = roleManager;
            _mySqlDb = mySqlDb;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _mySqlDb.NewReg.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("roleID,roleName")] Roles roles)
        {
            if (ModelState.IsValid)
            {
               //UPON POST ROLE NAME FROM INDEX IS TAKEN AND USED TO CREATE A NEW ROLE
                await _roleManager.CreateAsync(new IdentityRole(roles.roleName));
                await _authDb.SaveChangesAsync();

                //ADD TO PERSONAL DBS
                //_authDb.Roles.Add(roles);

                //NEW ENTITY TO COPY INFO
                Roles newRole = _roleManager.Roles
                    .Where(p => p.Name.Equals(roles.roleName))
                    .Select(rid => new Roles { roleID = rid.Id })
                    .FirstOrDefault();

                roles.roleID = newRole.roleID;
                
                //ADD NEW ROLE TO ROLES REPO - FOR EDITING
                _mySqlDb.Roles.Add(roles);

                await _mySqlDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _mySqlDb.NewReg.FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Edit(string id, [Bind("roleID,roleName")] Roles roles)
        {
            if (id != roles.roleID)
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
            return View(roles);
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
