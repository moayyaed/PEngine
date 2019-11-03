using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Data
{
    public class PostgresqlBlogContext : BlogContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(BlogContextFactory.ConnectionString);
    }
}
