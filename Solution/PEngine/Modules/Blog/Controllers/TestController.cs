using Microsoft.AspNetCore.Mvc;

namespace PEngine.Modules.Blog.Controllers
{
    [Area("Blog")]
    public class TestController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}