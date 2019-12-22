using System;

namespace PEngine.Modules.Blog.Models.File
{
    public class FileUploadResultModel
    {
        public Guid FileId { get; set; }
        public string Filename { get; set; }
        public long Filesize { get; set; }
    }
}