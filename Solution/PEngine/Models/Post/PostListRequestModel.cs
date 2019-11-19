using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Post
{
    public class PostListRequestModel
    {
        public string Category { get; set; }
        public int Page { get; set; }
    }
}
