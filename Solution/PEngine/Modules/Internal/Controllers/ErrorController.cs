using Microsoft.AspNetCore.Mvc;

namespace PEngine.Modules.Internal.Controllers
{
    [Area("Internal")]
    public class ErrorController : Controller
    {
        #region 4xx Error Codes
        [Route("/Error/404")]
        public ViewResult NotFoundHandler()
        {
            return View();
        }

        [Route("/Error/403")]
        public ViewResult ForbiddenHandler()
        {
            return View();
        }

        [Route("/Error/401")]
        public ViewResult Unauthorized()
        {
            return View();
        }
        
        [Route("/Error/400")]
        public ViewResult BadRequestHandler()
        {
            return View();
        }
        #endregion

        [Route("/Error/{code:int}")]
        public ViewResult Others(int code)
        {
            return View();
        }
    }
}