using Microsoft.EntityFrameworkCore;

namespace PEngine.Modules.Database
{
    public abstract class BlogDbContext : DbContext
    {
        protected BlogContext()	
        {	
            Database.EnsureCreated();	
        }	

        protected override void OnModelCreating(ModelBuilder builder)	
        {	

        }
    }
}