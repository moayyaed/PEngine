using Microsoft.EntityFrameworkCore;

namespace PEngine.Modules.Database
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