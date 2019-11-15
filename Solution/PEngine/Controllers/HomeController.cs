using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PEngine.Models.Data;

namespace PEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogContext context;
        
        public HomeController(BlogContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}