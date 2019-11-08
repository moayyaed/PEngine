using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Comment
{
    public class CommentModel
    {
        public long Id { get; set; }
        public long ParentId { get; set; } // Parent Comment Id when this Comment is Reply

        public string Content { get; set; }
        public bool IsHidden { get; set; }
        
        public string WriterIPAddr { get; set; }

        public string WriterName { get; set; }
        public string WriterEmail { get; set; }
        public string Password { get; set; }

    }
}
