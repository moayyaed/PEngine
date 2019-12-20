using Microsoft.EntityFrameworkCore;

namespace PEngine.Common.Components.Database.Contexts
{
    public class SqliteDbContext : BlogDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(this.LoadConnectionString());
    }
}