using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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

        public static void          Initialize(IServiceCollection service, DBMSType type)
        {
            if (Context != null)
            {
                return;
            }

            // TODO :: This code should be refactored
            switch (type)
            {
                case DBMSType.Postgresql:
                    Context = new PostgresqlBlogContext();
                    service.AddSingleton<BlogContext, PostgresqlBlogContext>();
                    break;

                case DBMSType.SQLite:
                    Context = new SqliteBlogContext();
                    service.AddSingleton<BlogContext, SqliteBlogContext>();
                    break;

                case DBMSType.SqlServer:
                    Context = new SqlServerBlogContext();
                    service.AddSingleton<BlogContext, SqlServerBlogContext>();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }

    public static class IApplicationBuilderExtension
    {
        public static IServiceCollection UseDatabase(this IServiceCollection service, 
                                                        DBMSType dbmsType, 
                                                        string connectionString)
        {
            BlogContextFactory.ConnectionString = connectionString;

            if (!string.IsNullOrEmpty(connectionString))
                BlogContextFactory.Initialize(service, dbmsType);
            
            return service;
        }
    }
}
