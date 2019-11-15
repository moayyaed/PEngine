using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Post
{
    public class PostCategoryModel
    {
        public string Name { get; set; }
        public string Module { get; set; }

        public string Arguments { get; set; }

        public List<string> ArgumentList => JsonConvert.DeserializeObject<List<string>>(Arguments);

        public string BuildUrl()
        {
            var args = String.Join("&", ArgumentList);
            
            return $"/Category/{Name}?{args}";
        }
    }
}
