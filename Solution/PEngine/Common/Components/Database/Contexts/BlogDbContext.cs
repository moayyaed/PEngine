using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PEngine.Common.Models;
using PEngine.Common.Models.Schema;

namespace PEngine.Common.Components.Database.Contexts
{
    public abstract class BlogDbContext : DbContext
    {
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        public DbSet<UserModel> Users { get; set; }
        
        /* To Ditch IdentityDbContext */
        public DbSet<IdentityRole<long>> Roles { get; set; }
        public DbSet<IdentityUserClaim<long>> UserClaims { get; set; } 
        public DbSet<IdentityUserRole<long>> UserRoles { get; set; }
        public DbSet<FileModel> Files { get; set; }

        protected BlogDbContext()	
        {	
            Database.EnsureCreated();	
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<long>>(eb => { eb.HasNoKey(); });

            base.OnModelCreating(modelBuilder);
        }
    }
}