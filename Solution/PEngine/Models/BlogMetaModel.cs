using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models
{
    public class BlogMetaModel
    {
        public string Title { get; set; }
        public bool   UseGateway { get; set; }
        public string Field { get; set; }
        public string Layout { get; set; }
    }
}
