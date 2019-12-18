using Microsoft.EntityFrameworkCore;

namespace PEngine.Modules.Database
{
    public class SqlserverDbContext : BlogDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)	
            => optionsBuilder.UseSqlServer("");
    }
}