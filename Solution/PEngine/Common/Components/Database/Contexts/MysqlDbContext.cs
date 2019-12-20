using Microsoft.EntityFrameworkCore;

namespace PEngine.Common.Components.Database.Contexts
{
    public class MysqlDbContext : BlogDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)	
            => optionsBuilder.UseMySQL(this.LoadConnectionString());
    }
}