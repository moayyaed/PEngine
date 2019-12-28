using System;

namespace PEngine.Common.Models.SchemaExtensions.Models
{
    public class CommentModifyLogModel
    {
        public DateTime Timestamp { get; set; }
        public string PrevContent { get; set; }
        public string NewContent { get; set; }
        public string IpAddress { get; set; }
    }
}