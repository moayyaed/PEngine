using Microsoft.EntityFrameworkCore;

namespace PEngine.Modules.Database
{
    public class PostgresqlDbContext : BlogDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)	
            => optionsBuilder.UseNpgsql(this.LoadConnectionString());
    }
}