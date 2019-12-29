using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using PEngine.Common.Components.Helpers;
using PEngine.Common.Models.Schema;
using PEngine.Modules.Member.Models;

namespace PEngine.Common.Models.SchemaExtensions
{
    public static class UserModelExtensions
    {
        public static string GetProfileImgPath(this UserModel model)
        {
            var path = $"~/Resources/Profile/{model.Id}";
            
            return File.Exists(path) ? path : null;
        }

        public static UserModel UpdateUser(this UserModel model, RegisterRequestModel source)
        {
            model.UserName = source.UserName;
            model.Signature = source.Signature;

            if (source.Password != null)
            {
                model.PasswordHash = CryptoHelper.Sha256(source.Password);
            }

            return model;
        }
    }
}