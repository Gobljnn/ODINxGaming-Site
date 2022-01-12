using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        protected int userIDC;
        public ExecsController(OdinXSiteMVC2Context context, IWebHostEnvironment webhost)
        {
            _context = context;
            _webHostEnvironment = webhost;

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
        public async Task<IActionResult> Create([Bind("execID,execFirstName,execLastName,execGamingTag,username,execTitle,favGame,execHierarchy,loginAmt,lastLogin, execPic")] Exec exec)
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
            userIDC = exec.execID;
            return View(exec);
        }

        // POST: Execs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("execID,execFirstName,execLastName,execGamingTag,username,execTitle,execHierarchy,favGame,loginAmt")] Exec exec)
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
            //return View(Details);
            return RedirectToAction(nameof(Index));
        }

        /*------------------------
                        -----------------------------------------------*/

        public async Task<IActionResult> Imgupload(int? id) {
            if (id == null) {
                return NotFound();
            }

            var exec = await _context.Exec.FindAsync(id);
            if (exec == null) {
                return NotFound();
            }
            return View(exec);
        }



        //E:\Github_Local_Repo\OdinxSite_Port\OdinXSiteMVC2\wwwroot\unver_images\Goblogo.png

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ActionName("Imgupload")]
        public async Task<IActionResult> Imgupload(IFormFile imageFile, UserImage userImage ) {

            //get the extension of the user uploaded file
            string ext = Path.GetExtension(imageFile.FileName);
            var id = userIDC;

            //jpg, jpeg, png, gif allowed
            if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".jif") {

                //Create a new path (in root folder) for the new user if folder does not exist

                //folder in wwwroor/unver_imgs
                var folderName = Path.Combine(_webHostEnvironment.WebRootPath, "unver_images");

                //combine folder name to user_IDX_ and then create directory if it doesnt exist
                var pathString = Path.Combine(folderName, "user_" + id + "X_");

                if (!Directory.Exists(pathString)) {
                    Directory.CreateDirectory(pathString);
                }

                //save file in user folder name and save in root with new name.
                var saveimg = Path.Combine(pathString, imageFile.FileName);

                using (var uploadingimg = new FileStream(saveimg, FileMode.Create)) {
                    await imageFile.CopyToAsync(uploadingimg);

                    userImage.imageName = imageFile.Name.ToString();
                    userImage.imagePath = saveimg;
                    userImage.userID = 1;

                    await _context.UserFiles.AddAsync(userImage);
                    await _context.SaveChangesAsync();
                    ViewData["Message"] = "The Selected File " + imageFile.FileName + " has been saved ";
                }
            }

            else {
                ViewData["Message"] = "The Selected File " + imageFile.FileName + " did not save. Check the image file type (only JPG, JPEG, GIF, PNG allowed  ";
            }

            //return View();
            return RedirectToAction(nameof(Index));
        }

        /*------------------------
                                -----------------------------------------------*/
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
