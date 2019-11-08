using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.File
{
    public class FileModel
    {
        public string Id { get; set; }

        // Which Module uploaded this file? (Check request integrity, prevent direct access)
        public string Module { get; set; }

        // Arguments for Module
        public string ModuleArgs { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
    }
}
