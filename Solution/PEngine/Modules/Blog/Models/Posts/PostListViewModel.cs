using System;
using System.Collections.Generic;
using PEngine.Common.Models.Schema;

namespace PEngine.Modules.Blog.Models.Posts
{
    public class PostListViewModel
    {
        public static PostListViewModel Project(PostModel post)
        {
            return new PostListViewModel
            {
                Id = post.Id,
                Title = post.Title,
                CreatedAt = post.CreatedAt,
                Content = post.Exerpt(300),
                Tags = post.GetTagList(),
                ReadCount = post.ReadCount,
                Private = post.Private
            };
        }
        
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public string[] Tags { get; set; }
        public long ReadCount { get; set; }
        public bool Private { get; set; }
    }
}