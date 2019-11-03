using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Data
{
    public enum DBMSType
    {
        Postgresql, SQLite, SqlServer
    }

    public class BlogContextFactory
    {
        public static string        ConnectionString { get; set; }
        public static BlogContext   Context { get; set; }

        public static void          Initialize(DBMSType type)
        {
            if (Context != null) return;

            switch (type)
            {
                case DBMSType.Postgresql:
                    Context = new PostgresqlBlogContext();
                    break;

                case DBMSType.SQLite:
                    Context = new SqliteBlogContext();
                    break;

                case DBMSType.SqlServer:
                    Context = new SqlServerBlogContext();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
