using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Post
{
    public class PostReadModel
    {
        public long Id { get; set; }

        public long SearchPage { get; set; }
        public string SearchFilter { get; set; }
        public string SearchKeyword { get; set; }
        public long SearchTimestamp { get; set; }

        public static PostReadModel WithId(long id)
        {
            return new PostReadModel { Id = id };
        }
    }
}
