using Microsoft.EntityFrameworkCore;

namespace PEngine.Modules.Database
{
    public class SqliteDbContext : BlogDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(this.LoadConnectionString());
    }
}