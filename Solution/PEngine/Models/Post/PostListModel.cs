using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Post
{
    public class PostListModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long WriterId { get; set; }
        public string WriterName { get; set; }
        public DateTime WrittenAt { get; set; }
        public string ThumbnailURL { get; set; }
        public string Abstract { get; set; }
        public long ReadCount { get; set; }
    }
}
