using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Search
{
    public class SearchRequestModel
    {
        public string Filter { get; set; }
        public bool SearchEntireSite { get; set; }
        public string SearchScope { get; set; }
        public string Keyword { get; set; }
    }
}
