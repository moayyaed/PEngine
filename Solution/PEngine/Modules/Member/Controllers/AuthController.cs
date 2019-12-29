using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PEngine.Common.Models.Schema;
using PEngine.Modules.Member.Models;

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

        public async Task<ViewResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update()
        {
            return View();
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
                                                    password, false, true)
                .ConfigureAwait(false);
            var redirectLocation = redirectTo ?? "/";
            
            if (result.Succeeded)
            {
                var user = await m_uiManager.GetUserAsync(User)
                                            .ConfigureAwait(false);
                
                user.LastLogin = DateTime.Now;

                var updateResult = m_uiManager.UpdateAsync(user)
                                              .ConfigureAwait(false);
                
                return Redirect(redirectLocation);
            }
            else if (result.IsLockedOut)
            {
                return RedirectToAction("LockedOut");
            }

            return View();
        }

        public async Task<ActionResult> SignOut()
        {
            await m_siManager.SignOutAsync()
                             .ConfigureAwait(false);

            return View();
        }

        public ActionResult LockedOut()
        {
            return View();
        }
    }
}