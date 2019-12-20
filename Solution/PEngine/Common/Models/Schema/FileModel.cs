using System;
using System.ComponentModel.DataAnnotations;

namespace PEngine.Common.Models.Schema
{
    public class FileModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Filename { get; set; }
        public long Filesize { get; set; }
        public string ContentType { get; set; }
        public string ActualPath { get; set; }
        
        public long DownloadedCount { get; set; }
        public DateTime UploadTime { get; set; }
    }
}