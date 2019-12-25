using System.Collections.Generic;
using PEngine.Common.Models.Schema;

namespace PEngine.Modules.Blog.Models.Posts
{
    public class PostWriteRequestModel
    {
        public string Category { get; set; }
        public string Title { get; set; }
        
        public string ContentType { get; set; }
        public string Content { get; set; }
        
        public string Tags { get; set; }
        public string Files { get; set; }
        
        public bool Private { get; set; }
        
        public bool Protected { get; set; }
        public string ProtectPassword { get; set; }
    }
}