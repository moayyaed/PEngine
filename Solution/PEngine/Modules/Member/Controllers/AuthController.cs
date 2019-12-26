using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PEngine.Common.Models.Schema;

namespace PEngine.Modules.Member.Controllers
{
    [Area("Member")]
    public class AuthController : Controller
    {
        private readonly SignInManager<UserModel> m_siManager;
        private readonly UserManager<UserModel> m_uiManager;
        
        public AuthController(SignInManager<UserModel> siManager, UserManager<UserModel> uiManager)
        {
            m_siManager = siManager;
            m_uiManager = uiManager;
        }

        public ViewResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(string email, string password, string redirectTo)
        {
            var result = await m_siManager.PasswordSignInAsync(email, 
                                                    password, false, true);
            var redirectLocation = redirectTo ?? "/";
            
            if (result.Succeeded)
            {
                var user = await m_uiManager.GetUserAsync(User);
                user.LastLogin = DateTime.Now;

                return Redirect(redirectLocation);
            }
            else if (result.IsLockedOut)
            {
                return RedirectToAction("LockedOut");
            }

            return View();
        }

        public ActionResult LockedOut()
        {
            return View();
        }
    }
}