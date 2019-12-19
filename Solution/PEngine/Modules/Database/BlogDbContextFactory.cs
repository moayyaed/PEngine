using System;
using Microsoft.Extensions.DependencyInjection;

namespace PEngine.Modules.Database
{
    public enum DBMSType	
    {	
        SqlServer = 0, Postgresql = 1, MySQL = 2, SQLite = 3	
    }

    public static class BlogDbContextInitializer
    {
        private static string ConnectionString { get; set; }

        private static void Initialize(IServiceCollection service, DBMSType type)
        {
            // TODO :: This code should be refactored	
            switch (type)
            {
                case DBMSType.Postgresql:
                    service.AddSingleton<BlogDbContext, PostgresqlDbContext>();
                    break;

                case DBMSType.MySQL:
                    service.AddSingleton<BlogDbContext, MysqlDbContext>();
                    break;

                case DBMSType.SQLite:
                    service.AddSingleton<BlogDbContext, SqliteDbContext>();
                    break;

                case DBMSType.SqlServer:
                    service.AddSingleton<BlogDbContext, SqlserverDbContext>();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public static string LoadConnectionString(this BlogDbContext context)
        {
            return ConnectionString;
        }
        
        public static IServiceCollection UseDatabase(this IServiceCollection service,
            DBMSType dbmsType,
            string connectionString)
        {
            ConnectionString = connectionString;

            if (!string.IsNullOrEmpty(connectionString))
            {
                Initialize(service, dbmsType);
            }

            return service;
        }
    }
}