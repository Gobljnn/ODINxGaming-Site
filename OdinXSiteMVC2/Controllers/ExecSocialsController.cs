using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Data;
using OdinXSiteMVC2.Models.Socials;

namespace OdinXSiteMVC2.Controllers
{
    [Authorize(Roles = "Plebs")]
    public class ExecSocialsController : Controller
    {
        private readonly OdinXSiteMVC2Context _context;

        public ExecSocialsController(OdinXSiteMVC2Context context)
        {
            _context = context;
        }

        // GET: ExecSocials
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExecSocial.ToListAsync());
        }

        // GET: ExecSocials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execSocial = await _context.ExecSocial
                .FirstOrDefaultAsync(m => m.socialID == id);
            if (execSocial == null)
            {
                return NotFound();
            }

            return View(execSocial);
        }

        // GET: ExecSocials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExecSocials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("socialID,execId,execName,discordName,discordLink,ttvlink,instaLink,twitLink,tiktokLink,scLink,live")] ExecSocial execSocial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(execSocial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(execSocial);
        }

        // GET: ExecSocials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execSocial = await _context.ExecSocial.FindAsync(id);
            if (execSocial == null)
            {
                return NotFound();
            }
            return View(execSocial);
        }

        // POST: ExecSocials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("socialID,execId,execName,discordName,discordLink,ttvlink,instaLink,twitLink,tiktokLink,scLink,live")] ExecSocial execSocial)
        {
            if (id != execSocial.socialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(execSocial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecSocialExists(execSocial.socialID))
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
            return View(execSocial);
        }

        // GET: ExecSocials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execSocial = await _context.ExecSocial
                .FirstOrDefaultAsync(m => m.socialID == id);
            if (execSocial == null)
            {
                return NotFound();
            }

            return View(execSocial);
        }

        // POST: ExecSocials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var execSocial = await _context.ExecSocial.FindAsync(id);
            _context.ExecSocial.Remove(execSocial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExecSocialExists(int id)
        {
            return _context.ExecSocial.Any(e => e.socialID == id);
        }
    }
}
