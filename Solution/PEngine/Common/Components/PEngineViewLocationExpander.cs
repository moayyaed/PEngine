using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace PEngine.Common.Components
{
    public class PEngineViewLocationExpander : IViewLocationExpander
    {
        public static IEnumerable<string> ExpandViewLocations(
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

        public static void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["PEngineViewLocation"] = nameof(PEngineViewLocationExpander);
        }
    }
}