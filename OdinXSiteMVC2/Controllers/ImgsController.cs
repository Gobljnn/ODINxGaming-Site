using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using OdinXSiteMVC2.Data;

namespace OdinXSiteMVC2.Controllers {
    public class ImgsController : Controller {

        private readonly OdinXSiteMVC2Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImgsController(OdinXSiteMVC2Context context, IWebHostEnvironment webhost) {
            _context = context;
            _webHostEnvironment = webhost;

        }

        public IActionResult Index() {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile imageFile) {



            var folderName = Path.Combine(_webHostEnvironment.WebRootPath, "unver_images");
            var pathString = Path.Combine(folderName, "test");
            Directory.CreateDirectory(pathString);
            var saveimg = Path.Combine(pathString, imageFile.FileName);
            string ext = Path.GetExtension(imageFile.FileName);

            if (ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".jif") {
                using (var uploadingimg = new FileStream(saveimg, FileMode.Create)) {
                    await imageFile.CopyToAsync(uploadingimg);
                    ViewData["Message"] = "The Selected File " + imageFile.FileName + " has been saved "; 
                }
            }

            else {
                ViewData["Message"] = "The Selected File " + imageFile.FileName + " did not save. Check the image file type (only JPG, JPEG, GIF, PNG allowed  ";
            }

            return View();
        }

        [HttpPost]
        [ActionName("Cheers")]
        public async Task<IActionResult> Cheers(IFormFile imageFile) {



            var folderName = Path.Combine(_webHostEnvironment.WebRootPath, "unver_images");
            var pathString = Path.Combine(folderName,  "test");
            Directory.CreateDirectory(pathString);
            var saveimg = Path.Combine(pathString, imageFile.FileName);
            string ext = Path.GetExtension(imageFile.FileName);

            if (ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".jif") {
                using (var uploadingimg = new FileStream(saveimg, FileMode.Create)) {
                    await imageFile.CopyToAsync(uploadingimg);
                    ViewData["Message"] = "The Selected File " + imageFile.FileName + " has been saved ";
                }
            }

            else {
                ViewData["Message"] = "The Selected File " + imageFile.FileName + " did not save. Check the image file type (only JPG, JPEG, GIF, PNG allowed  ";
            }

            return View();
        }
    }
}
