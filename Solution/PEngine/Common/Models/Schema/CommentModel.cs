using System.ComponentModel.DataAnnotations;

namespace PEngine.Common.Models.Schema
{
    public class CommentModel
    {
        [Key]
        public long Id { get; set; }
        public long PostId { get; set; }

        public long WriterId { get; set; }
        public string Writer { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public string Content { get; set; }
        
        public string IpAddress { get; set; }
        public bool IsDeleted { get; set; }
        
        public long ReplyFor { get; set; }
    }
}