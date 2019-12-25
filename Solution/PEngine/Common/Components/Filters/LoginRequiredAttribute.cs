using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PEngine.Common.Components.Filters
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        protected Controller currentController;

        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            currentController = context.Controller as Controller;
            
            if (currentController?.User.Identity.IsAuthenticated == false)
            {
                context.Result = new RedirectResult("/Member/Auth/Login");
            }
        }
    }
}