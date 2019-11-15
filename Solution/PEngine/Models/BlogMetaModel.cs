using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models
{
    public class BlogMetaModel
    {
        public string Title { get; set; } = "PEngine";
        public string ThemeColor { get; set; } = "#ae009c";
        public bool UseGateway { get; set; } = true;
        public string Field { get; set; } = "Personal Blog";
        public string Skin { get; set; } = "default";
    }
}
