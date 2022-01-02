using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Data;
using OdinXSiteMVC2.Models;

namespace OdinXSiteMVC2.Controllers
{
    public class ExecsController : Controller
    {
        private readonly OdinXSiteMVC2Context _context;

        public ExecsController(OdinXSiteMVC2Context context)
        {
            _context = context;
        }


        // GET: Execs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exec.ToListAsync());
        }

        // GET: Execs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec = await _context.Exec
                .FirstOrDefaultAsync(m => m.execID == id);
            if (exec == null)
            {
                return NotFound();
            }

            return View(exec);
        }

        // GET: Execs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Execs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("execID,execFirstName,execLastName,execGamingTag,username,execTitle,favGame,execHierarchy,loginAmt,lastLogin")] Exec exec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec);
        }

        // GET: Execs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec = await _context.Exec.FindAsync(id);
            if (exec == null)
            {
                return NotFound();
            }
            return View(exec);
        }

        // POST: Execs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("execID,execFirstName,execLastName,execGamingTag,username,execTitle,execHierarchy,favGame,loginAmt,lastLogin")] Exec exec)
        {
            if (id != exec.execID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecExists(exec.execID))
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
            return View(exec);
        }

        // GET: Execs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec = await _context.Exec
                .FirstOrDefaultAsync(m => m.execID == id);
            if (exec == null)
            {
                return NotFound();
            }

            return View(exec);
        }

        // POST: Execs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec = await _context.Exec.FindAsync(id);
            _context.Exec.Remove(exec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExecExists(int id)
        {
            return _context.Exec.Any(e => e.execID == id);
        }
    }
}
