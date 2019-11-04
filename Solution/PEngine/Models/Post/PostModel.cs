using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Post
{
    public class PostModel
    {
        [Key]
        public long Id { get; set; }
        public long WrittenBy { get; set; }
        public long ReadCount { get; set; }

        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime WrittenAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }

        // LaTeX, Markdown, or HTML
        public string PostTextType { get; set; }
        public string Content { get; set; }
        // Used when PostTextType is LaTeX or Markdown
        public string CachePath { get; set; }

        public bool IsProtected { get; set; }
        public string ProtectPassword { get; set; }
        
        public bool IsCommentEnabled { get; set; }
    }
}
