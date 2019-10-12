using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PEngine.Controllers
{
    [ApiController]
    [Route("/manage/[action]")]
    [AutoValidateAntiforgeryToken]
    public class ManageApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}