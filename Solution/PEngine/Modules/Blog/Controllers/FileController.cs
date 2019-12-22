using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEngine.Common.Components.Database.Contexts;
using PEngine.Common.Models.Schema;
using PEngine.Modules.Blog.Models.File;

namespace PEngine.Modules.Blog.Controllers
{
    using SysFile = System.IO.File;
    
    [Area("Blog")]
    public class FileController : Controller
    {
        private BlogDbContext m_db;

        public FileController(BlogDbContext db)
        {
            m_db = db;
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
                var file = await m_db.Files.FirstOrDefaultAsync(f => f.Id == fileGuid);

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

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Upload(List<IFormFile> uploadingFiles)
        {
            var uploadResult = new List<FileUploadResultModel>();
            
            foreach (var file in uploadingFiles)
            {
                var newFile = await m_db.Files.AddAsync(
                    new FileModel {
                        Id = Guid.NewGuid(),
                        Filename = file.FileName,
                        ContentType = file.ContentType,
                        Filesize = file.Length,
                        ActualPath = FileModel.CreateRandomPath() // Actual Path Creating Algorithm?
                    });

                if (newFile.State == EntityState.Added)
                {
                    using var targetStream = SysFile.Create(newFile.Entity.ActualPath);
                    await file.CopyToAsync(targetStream);

                    uploadResult.Add(
                        new FileUploadResultModel
                        {
                            FileId = newFile.Entity.Id,
                            Filename = newFile.Entity.Filename,
                            Filesize = newFile.Entity.Filesize
                        });
                }
            }

            m_db.SaveChanges();
            return Json(uploadResult);
        }
    }
}