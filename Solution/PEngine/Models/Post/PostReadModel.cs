using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Post
{
    public class PostReadModel
    {
        public long id { get; set; }

        public long searchPage { get; set; }
        public string searchFilter { get; set; }
        public string searchKeyword { get; set; }
        public long searchTimestamp { get; set; }

        public static PostReadModel WithId(long id)
        {
            return new PostReadModel { id = id };
        }
    }
}
