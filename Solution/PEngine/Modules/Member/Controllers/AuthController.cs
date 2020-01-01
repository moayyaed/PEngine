using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PEngine.Common.Models;
using PEngine.Common.Models.Schema;
using PEngine.Common.Models.SchemaExtensions;
using PEngine.Modules.Member.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace PEngine.Modules.Member.Controllers
{
    [Area("Member")]
    public class AuthController : Controller
    {
        private readonly SignInManager<UserModel> m_siManager;
        private readonly UserManager<UserModel> m_uManager;
        
        public AuthController(SignInManager<UserModel> siManager, 
                              UserManager<UserModel> uManager)
        {
            m_siManager = siManager;
            m_uManager = uManager;
        }

        public async Task<ViewResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Register(RegisterRequestModel model)
        {
            var result = new ApiResultModel();
            var user = new UserModel();

            /* Validate Input */
            
            user.UpdateUser(model);
            var createResult = await m_uManager.CreateAsync(user, model.Password)
                                                .ConfigureAwait(false);

            result.Success = createResult.Succeeded;
            if (!result.Success)
            {
                result.Message = createResult.Errors.First()
                                             .Description;
            }

            return Json(result);
        }

        public ViewResult SignIn(string redirectTo)
        {
            ViewData["RedirectTo"] = redirectTo ?? "/";
            ViewData["Logged"] = User.Identity.IsAuthenticated;

            var cc = m_siManager.Context.User;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SignIn(string email, string password)
        {
            var result = new ApiResultModel();
            
            var foundUser = m_uManager.FindByEmailAsync(email).Result;
            if (foundUser is null)
            {
                result.Message = "Failed to login";
                return Json(result);
            }
            
            var siResult = await m_siManager.PasswordSignInAsync(foundUser, password, 
                                             isPersistent: true,
                                             lockoutOnFailure: true)
                .ConfigureAwait(false);

            result.Success = siResult.Succeeded;

            
            if (siResult == SignInResult.Success)
            {
                foundUser.LastLogin = DateTime.Now;

                await m_uManager.UpdateAsync(foundUser)
                                 .ConfigureAwait(false);
            }
            else if (siResult == SignInResult.LockedOut)
            {
                result.Message = "Account locked out due to reach of maximum fail count";
            }
            else if (siResult == SignInResult.NotAllowed)
            {
                result.Message = "Account is not allowed to login!";
            }
            else
            {
                result.Message = "Failed to login";
            }
            
            return Json(result);
        }

        public async Task<ActionResult> SignOut(string redirectTo)
        {
            await m_siManager.SignOutAsync()
                             .ConfigureAwait(false);

            return Redirect(redirectTo ?? "/");
        }

        public ActionResult LockedOut()
        {
            return View();
        }
    }
}