using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEngine.Common.Components.Database.Contexts;
using PEngine.Common.Models.Schema;

namespace PEngine.Modules.Blog.Controllers
{
    using SysFile = System.IO.File;
    
    [Area("Blog")]
    public class FileController : Controller
    {
        private DbSet<FileModel> m_files;

        public FileController(BlogDbContext db)
        {
            m_files = db.Files;
        }

        [HttpGet("/Blog/File/{fileGuid}")]
        public async Task<ActionResult> Download(Guid fileGuid)
        {
            if (fileGuid == default)
            {
                return StatusCode(400);
            }
            
            try
            {
                var file = await m_files.FirstOrDefaultAsync(f => f.Id == fileGuid);

                using var fileStream = SysFile.OpenRead(file.ActualPath);
                return File(fileStream, file.ContentType);
            }
            catch (FileNotFoundException)
            {
                return StatusCode(404);
            }
            catch (IOException)
            {
                return StatusCode(500);
            }
        }
    }
}