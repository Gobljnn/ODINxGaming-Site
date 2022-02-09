using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Data;
using OdinXSiteMVC2.Models;
using OdinXSiteMVC2.Models.DTO;

namespace OdinXSiteMVC2.Controllers
{
    [Authorize(Roles = "Master, Admin")]
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

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var members = _mySqlDb.NewReg.Include(n => n.Roles);
            return View(await members.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newRegDTO = await _mySqlDb.NewReg
                .Include(n => n.Roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newRegDTO == null)
            {
                return NotFound();
            }

            return View(newRegDTO);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            ViewData["roleId"] = new SelectList(_mySqlDb.Roles, "roleID", "roleID");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,userName,email,profilePic,gamerTag,role,roleId")] NewRegDTO newRegDTO)
        {
            if (ModelState.IsValid)
            {
                _mySqlDb.Add(newRegDTO);
                await _mySqlDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["roleId"] = new SelectList(_mySqlDb.Roles, "roleID", "roleID", newRegDTO.roleId);
            return View(newRegDTO);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newRegDTO = await _mySqlDb.NewReg.FindAsync(id);
            if (newRegDTO == null)
            {
                return NotFound();
            }
            ViewData["roleId"] = new SelectList(_mySqlDb.Roles, "roleID", "roleName", newRegDTO.roleId);
            return View(newRegDTO);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,firstName,lastName,userName,email,profilePic,gamerTag,role,roleId")] NewRegDTO newRegDTO)
        {
            var user = await _userManager.FindByIdAsync(id);
            var _user = await _mySqlDb.NewReg.FindAsync(id);


            if (id != newRegDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    //Find the role name by Id
                    var _role = await _roleManager.FindByIdAsync(newRegDTO.roleId);

                    //add user to role
                    var changerole = await _userManager.AddToRoleAsync(user, _role.Name);

                    //Get role name
                    newRegDTO.role = _role.Name;

                    //update
                    await _userManager.UpdateAsync(user);

                    if (_role.Name.Equals("Admin")) {

                        var newExec = new Exec {
                            execID = user.Id,
                            execFirstName = user.firstName,
                            execLastName = user.lastName,
                            execGamingTag = user.UserName,
                            execPic = _user.profilePic

                        };

                        

                        _mySqlDb.Exec.Add(newExec);
                        _mySqlDb.SaveChanges();
                    }

                    _user.role = _role.Name;
                    _mySqlDb.SaveChanges();

                    //_mySqlDb.Update(newRegDTO);




                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!NewRegDTOExists(newRegDTO.Id))
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
            await _mySqlDb.SaveChangesAsync();
            ViewData["roleId"] = new SelectList(_mySqlDb.Roles, "roleID", "roleID", newRegDTO.roleId);
            return View(newRegDTO);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newRegDTO = await _mySqlDb.NewReg
                .Include(n => n.Roles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newRegDTO == null)
            {
                return NotFound();
            }

            return View(newRegDTO);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var newRegDTO = await _mySqlDb.NewReg.FindAsync(id);
            _mySqlDb.NewReg.Remove(newRegDTO);
            await _mySqlDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewRegDTOExists(string id)
        {
            return _mySqlDb.NewReg.Any(e => e.Id == id);
        }
    }
}
