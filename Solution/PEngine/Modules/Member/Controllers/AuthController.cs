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
        private SignInManager<UserModel> m_siManager;
        private UserManager<UserModel> m_uiManager;
        
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

            if (result.Succeeded)
            {
                var user = await m_uiManager.GetUserAsync(User);
                user.LastLogin = DateTime.Now;

                if (string.IsNullOrEmpty(redirectTo))
                {
                    redirectTo = "/";
                }
                
                return Redirect(redirectTo);
            }

            return result.IsLockedOut ? RedirectToAction("LockedOut") : RedirectToAction();
        }

        public ActionResult LockedOut()
        {
            return View();
        }
    }
}