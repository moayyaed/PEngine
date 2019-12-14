using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PEngine.Models.User;

namespace PEngine.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class UserController : Controller
    {
        private readonly SignInManager<UserModel> m_signInManager;
        private readonly UserManager<UserModel> m_userManager;

        public UserController(SignInManager<UserModel> signInManager, 
                              UserManager<UserModel> userManager)
        {
            m_signInManager = signInManager;
            m_userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var failureResult = new LoginFailureInfoModel();

            if (ModelState.IsValid)
            {
                var result = await m_signInManager.PasswordSignInAsync(
                                            model.Username,
                                            model.Password,
                                            model.RememberMe,
                                            lockoutOnFailure: true)
                                                  .ConfigureAwait(false);

                if (result.Succeeded)
                {
                    if (model.RedirectTo == null)
                    {
                        model.RedirectTo = "/";
                    }

                    return RedirectPermanent(model.RedirectTo);
                }
                /*
                 * else if (result.RequiresTwoFactor)
                 * {
                 *     // TODO: Handle 2FA (Not Planned, But Later)   
                 * }
                 */ 
                else if (result.IsLockedOut)
                {
                    failureResult.Message = "Account Locked, Please wait until unlock...";
                }
                
            }

            if (failureResult.Message == null)
                failureResult.Message = "Bad Request";
            
            return View(failureResult);
        }
    }
}