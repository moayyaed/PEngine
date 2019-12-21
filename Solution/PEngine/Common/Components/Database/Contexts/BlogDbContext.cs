using Microsoft.EntityFrameworkCore;
using PEngine.Common.Models.Schema;

namespace PEngine.Common.Components.Database.Contexts
{
    public abstract class BlogDbContext : DbContext
    {
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected BlogDbContext()	
        {	
            Database.EnsureCreated();	
        }	

        protected override void OnModelCreating(ModelBuilder builder)	
        {	

        }
    }
}