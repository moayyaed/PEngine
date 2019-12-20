using Microsoft.AspNetCore.Mvc;

namespace PEngine.Modules.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}