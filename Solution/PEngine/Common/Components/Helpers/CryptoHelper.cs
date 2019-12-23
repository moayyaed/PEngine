using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace PEngine.Common.Components.Helpers
{
    public class CryptoHelper
    {
        public static string Sha256(string source)
        {
            using var sha = SHA256.Create();
            var sourceBytes = Encoding.UTF8.GetBytes(source);
            var result = BitConverter.ToString(sha.ComputeHash(sourceBytes));

            return EnumerableExtensions.Join(result.Split('-'), ""); 
        }
    }
}