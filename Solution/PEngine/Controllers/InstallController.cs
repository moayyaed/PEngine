using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PEngine.Helper;
using PEngine.Models.Data;

namespace PEngine.Controllers
{
    public class InstallController : Controller
    {
        public InstallController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> Complete()
        {
            return View();
        }
    }
}