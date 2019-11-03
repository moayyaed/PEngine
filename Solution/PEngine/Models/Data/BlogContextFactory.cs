using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Data
{
    public enum DBMSType
    {
        SqlServer = 0, Postgresql = 1, SQLite = 2
    }

    public static class BlogContextFactory
    {
        public static string        ConnectionString { get; set; }
        public static BlogContext   Context { get; set; }

        public static void          Initialize(DBMSType type)
        {
            if (Context != null)
            {
                return;
            }

            Context = type switch
            {
                DBMSType.Postgresql => new PostgresqlBlogContext(),

                DBMSType.SQLite => new SqliteBlogContext(),

                DBMSType.SqlServer => new SqlServerBlogContext(),

                _ => throw new NotImplementedException(),
            };
        }
    }

    public static class IApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabase(this IApplicationBuilder builder, 
                                                        DBMSType dbmsType, 
                                                        string connectionString)
        {
            BlogContextFactory.ConnectionString = connectionString;
            BlogContextFactory.Initialize(dbmsType);
            
            return builder;
        }
    }
}
