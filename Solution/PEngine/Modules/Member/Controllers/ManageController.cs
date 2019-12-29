using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PEngine.Common.Components.Filters;
using PEngine.Common.Models;
using PEngine.Common.Models.Schema;
using PEngine.Modules.Member.Models;

namespace PEngine.Modules.Member.Controllers
{
    [Area("Member")]
    [LoginRequired]
    public class ManageController : Controller
    {
        private UserModel m_currentUser;
        private UserManager<UserModel> m_manager;
        
        public ManageController(UserManager<UserModel> manager)
        {
            m_manager = manager;
            m_currentUser = manager.GetUserAsync(User).Result;
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
            
            return Json(result);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete()
        {
            var result = new ApiResultModel();

            // TODO: Check this user is the last user
            return Json(result);
        }
    }
}