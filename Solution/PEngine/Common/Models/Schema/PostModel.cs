using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PEngine.Common.Models.Schema
{
    public class PostModel
    {
        [Key]
        public long Id { get; set; }
        
        public long Writer { get; set; }
        public string WriterName { get; set; }
        
        public string Category { get; set; }
        public string Title { get; set; }
        
        public DateTime CreatedAt  { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
        
        public string ContentType { get; set; }
        public string ContentCachePath { get; set; }
        public string Content { get; set; }
        
        public long ReadCount { get; set; }
        
        public bool Private { get; set; }
        public bool Protected { get; set; }
        public string ProtectPassword { get; set; }
        
        public string Tags { get; set; }
        public string Files { get; set; }
        
    }
}