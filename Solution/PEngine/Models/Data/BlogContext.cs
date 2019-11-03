using Microsoft.EntityFrameworkCore;
using PEngine.Models.Comment;
using PEngine.Models.File;
using PEngine.Models.Post;
using PEngine.Models.User;

namespace PEngine.Models.Data
{
    public abstract class BlogContext : DbContext
    {
        public DbSet<BlogMetaModel> Metadata { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<PostCategoryModel> PostCategories { get; set; }
    }
}
