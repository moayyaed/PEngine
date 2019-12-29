using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PEngine.Common.Components.Filters;
using PEngine.Common.Models;
using PEngine.Common.Models.Schema;
using PEngine.Common.Models.SchemaExtensions;
using PEngine.Modules.Member.Models;

namespace PEngine.Modules.Member.Controllers
{
    [Area("Member")]
    [LoginRequired]
    public class ManageController : Controller
    {
        private UserModel m_currentUser;
        private UserManager<UserModel> m_uManager;

        private SignInManager<UserModel> m_siManager;
        
        public ManageController(SignInManager<UserModel> siManager, UserManager<UserModel> uManager)
        {
            m_uManager = uManager;
            m_currentUser = uManager.GetUserAsync(User).Result;
        }
        
        public IActionResult Index()
        {
            return View(m_currentUser);
        }
        
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Update(RegisterRequestModel model)
        {
            var result = new ApiResultModel();

            m_currentUser.UpdateUser(model);
            var updateResult = await m_uManager.UpdateAsync(m_currentUser)
                                              .ConfigureAwait(false);
            result.Success = updateResult.Succeeded;
            
            return Json(result);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete()
        {
            var result = new ApiResultModel();

            var deleteResult = await m_uManager.DeleteAsync(m_currentUser)
                                              .ConfigureAwait(false);
            result.Success = deleteResult.Succeeded;

            if (result.Success)
            {
                await m_siManager.SignOutAsync()
                                 .ConfigureAwait(false);
                /*
                 * TODO: Check this user is the last user
                 */
            }

            return Json(result);
        }
    }
}