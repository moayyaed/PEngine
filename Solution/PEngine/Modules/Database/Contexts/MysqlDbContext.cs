using Microsoft.EntityFrameworkCore;

namespace PEngine.Modules.Database
{
    public class MysqlDbContext : BlogDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)	
            => optionsBuilder.UseMySQL("");
    }
}