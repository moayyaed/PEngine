using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace PEngine.Common.Components
{
    public class PEngineViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var customLocations = new []
            {
                "/Modules/{2}/Views/{1}/{0}.cshtml",
                "/Modules/{2}/Views/Shared/{0}.cshtml",
                "/Common/Views/Shared/{0}.cshtml"
            };
            
            return customLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            if (context is null)
            {
                return;
            }
            
            context.Values["PEngineViewLocation"] = nameof(PEngineViewLocationExpander);
        }
    }
}