using Microsoft.EntityFrameworkCore;

namespace PEngine.Common.Components.Database.Contexts
{
    public class SqlserverDbContext : BlogDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)	
            => optionsBuilder.UseSqlServer(this.LoadConnectionString());
    }
}