using Microsoft.EntityFrameworkCore;

namespace PEngine.Common.Components.Database.Contexts
{
    public class PostgresqlDbContext : BlogDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)	
            => optionsBuilder.UseNpgsql(this.LoadConnectionString());
    }
}