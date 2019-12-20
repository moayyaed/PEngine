using Microsoft.EntityFrameworkCore;

namespace PEngine.Common.Components.Database.Contexts
{
    public abstract class BlogDbContext : DbContext
    {
        protected BlogDbContext()	
        {	
            Database.EnsureCreated();	
        }	

        protected override void OnModelCreating(ModelBuilder builder)	
        {	

        }
    }
}