using System;
using System.Collections.Generic;

namespace PEngine.Modules.Blog.Models.Posts
{
    public class PostListViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
        public long ReadCount { get; set; }
        public bool Private { get; set; }
    }
}