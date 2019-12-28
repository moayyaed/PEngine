using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PEngine.Common.Components.Helpers
{
    public static class CryptoHelper
    {
        public static string Sha256(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }
            
            using var sha = SHA256.Create();
            var sourceBytes = Encoding.UTF8.GetBytes(source);
            var result = BitConverter.ToString(sha.ComputeHash(sourceBytes));

            return string.Join(string.Empty, result.Split('-'));
        }
    }
}