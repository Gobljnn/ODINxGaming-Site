using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdinXSiteMVC2.Data;
using OdinXSiteMVC2.Models;

namespace OdinXSiteMVC2.Controllers
{
    //[Authorize(Roles = "Exec")]
    public class ExecsController : Controller
    {
        
        private readonly OdinXSiteMVC2Context _mySqlDb;
        private readonly IWebHostEnvironment _webHostEnvironment;

        protected string userIDC;
        public ExecsController(OdinXSiteMVC2Context context, IWebHostEnvironment webhost)
        {
            _mySqlDb = context;
            _webHostEnvironment = webhost;

        }
        

        // GET: Execs
        public async Task<IActionResult> Index()
        {
            return View(await _mySqlDb.Exec.ToListAsync());
        }


        public IEnumerable<string> Info(string? id) {

            //Path of Exec Pic will be found here through lambda - use in img source in index of exec.
            ViewData["Exec"] = id;

       
            var info = _mySqlDb.Exec
                .Where(p => p.execID == id)
                .Select(p => p.bio);
            //.ToList(); use this and you can change IEmunarable (which is more flexible) to List<string>

            if (info == null || info.Count() == 0) {
                return new List<string> { "No Products Found" };
            }

            return info;
        }

        public IEnumerable<string> bio(string? id) {
            var info = _mySqlDb.Exec
                .Where(p => p.execID == id)
                .Select(p => p.bio);
            //.ToList(); use this and you can change IEmunarable (which is more flexible) to List<string>

            if (info == null || info.Count() == 0) {
                return new List<string> { "No Products Found" };
            }

            return info;
        }


        // GET: Execs/Details/5 - USED TO SEE SPECIFIC INFO ON EXECS - ADD A MODAL - AT A LATER DATE#GOB
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec = await _mySqlDb.Exec
                .FirstOrDefaultAsync(m => m.execID == id);
            if (exec == null)
            {
                return NotFound();
            }

            return View(exec);
        }

        // GET: Execs/Create - REMOVE  - AT A LATER DATE#GOB
        public IActionResult Create()
        {
            return View();
        }

        // POST: Execs/Create  - AT A LATER DATE#GOB
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("execID,execFirstName,execLastName,execGamingTag,username,execTitle,favGame,execHierarchy,loginAmt,lastLogin, execPic")] Exec exec)
        {
            if (ModelState.IsValid)
            {
                _mySqlDb.Add(exec);
                await _mySqlDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec);
        }

        // GET: Execs/Edit/5  - AT A LATER DATE#GOB
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec = await _mySqlDb.Exec.FindAsync(id);
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
        public async Task<IActionResult> Edit(string id, [Bind("execID,execFirstName,execLastName,execGamingTag,username,execTitle,execHierarchy,favGame,loginAmt")] Exec exec)
        {
            if (id != exec.execID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                
                try
                {
                    _mySqlDb.Update(exec);
                    await _mySqlDb.SaveChangesAsync();

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

            var exec = await _mySqlDb.Exec.FindAsync(id);
            if (exec == null) {
                return NotFound();
            }
            return View(exec);
        }



        //iMAGE UPLOADER -   - AT A LATER DATE#GOB

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

                    await _mySqlDb.UserFiles.AddAsync(userImage);
                    await _mySqlDb.SaveChangesAsync();
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
        // GET: Execs/Delete/5 - REMOVE   - AT A LATER DATE#GOB
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec = await _mySqlDb.Exec
                .FirstOrDefaultAsync(m => m.execID == id);
            if (exec == null)
            {
                return NotFound();
            }

            return View(exec);
        }

        // POST: Execs/Delete/5  REMOVE - AT A LATER DATE#GOB
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec = await _mySqlDb.Exec.FindAsync(id);
            _mySqlDb.Exec.Remove(exec);
            await _mySqlDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExecExists(string id)
        {
            return _mySqlDb.Exec.Any(e => e.execID == id);
        }
    }
}
