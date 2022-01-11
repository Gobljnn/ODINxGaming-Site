using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace OdinXSiteMVC2.Controllers {
    public class ImgsController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
