using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using PEngine.Common.Models.Schema;

namespace PEngine.Common.Models.SchemaExtensions
{
    public static class UserModelExtensions
    {
        public static string GetProfileImgPath(this UserModel model)
        {
            var path = $"~/Resources/Profile/{model.Id}";
            
            return File.Exists(path) ? path : null;
        }
    }
}