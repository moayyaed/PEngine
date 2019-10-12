using Microsoft.EntityFrameworkCore;
using PEngine.Models.Comment;
using PEngine.Models.File;
using PEngine.Models.Post;
using PEngine.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("");
    }
}
