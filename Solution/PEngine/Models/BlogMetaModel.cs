using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models
{
    public class BlogMetaModel
    {
        private static readonly BlogMetaModel defaultStatic = new BlogMetaModel();
        public static BlogMetaModel DefaultStatic => defaultStatic;

        public string Title { get; set; } = "PEngine";
        public bool UseGateway { get; set; } = true;
        public string Field { get; set; } = "Personal Blog";
        public string Skin { get; set; } = "default";
        public string Language { get; set; } = "ko";
    }
}
