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
        public bool UseAtom { get; set; }
        public bool UseRss { get; set; }
        public string Field { get; set; } = "Personal Blog";
        public string Skin { get; set; } = "default";
        public string Language { get; set; } = "ko";
        public bool UseImageResize { get; set; } = true;
        public int ImageResizeWidth { get; set; } = 300;
        public bool UseImageWatermark { get; set; } = true;
        public int WatermarkPosition { get; set; }
        public string WatermarkImageId { get; set; }
        public double WatermarkOpaque { get; set; } = 0.5;
        public bool Installed { get; set; }
    }
}
