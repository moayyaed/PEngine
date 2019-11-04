using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Post
{
    public class PostCategoryModel
    {
        public string Name { get; set; }
        public string Module { get; set; }
        public List<string> Arguments { get; set; }

        public string BuildUrl()
        {
            var args = String.Join("&", Arguments);
            
            return $"/Category/{Name}?{args}";
        }
    }
}
