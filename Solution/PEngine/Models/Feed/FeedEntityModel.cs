using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Feed
{
    public class FeedEntityModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Summary { get; set; }
    }
}
