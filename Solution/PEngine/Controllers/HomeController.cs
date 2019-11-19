using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PEngine.Helper;
using PEngine.Models.Data;

namespace PEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession session;
        private readonly BlogContext context;
        
        public HomeController(BlogContext _context, IHttpContextAccessor _accessor)
        {
            session = _accessor.HttpContext.Session;
        }

        public IActionResult Index()
        {
            if (StaticHelper.Meta.UseGateway && 
                session.GetInt32("GatewayViewed") != 1)
            {
                session.SetInt32("GatewayViewed", 1);
                return View("Gateway");
            }
            else
            {
                return View();
            }
        }
    }
}