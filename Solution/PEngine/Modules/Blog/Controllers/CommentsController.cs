using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEngine.Common.Components.Database.Contexts;

namespace PEngine.Modules.Blog.Controllers
{
    public class CommentsController : Controller
    {
        private readonly BlogDbContext m_db;
        
        public CommentsController(BlogDbContext context)
        {
            m_db = context;
        }
        
        public async Task<JsonResult> Index(long postId)
        {
            var post = await m_db.Comments.Where(post => post.Id == postId)
                .ToListAsync()
                .ConfigureAwait(false);

            return Json(post);
        }

        [HttpPost]
        public async Task<JsonResult> Write(/* CommentWriteRequestModel */)
        {
            return Json("");
        }
    }
}