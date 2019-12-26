using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEngine.Common.Components.Database.Contexts;
using PEngine.Common.Components.Filters;
using PEngine.Common.Components.Helpers;
using PEngine.Common.Models.Schema;
using PEngine.Modules.Blog.Models.Posts;

namespace PEngine.Modules.Blog.Controllers
{
    [Area("Blog")]
    public class PostsController : Controller
    {
        private readonly BlogDbContext m_db;

        public PostsController(BlogDbContext db)
        {
            m_db = db;
        }

        public async Task<ViewResult> List(string searchKeyword, int page)
        {
            var keyword = searchKeyword ?? "";
            var showPrivate = User.Identity.IsAuthenticated;
            var pageNo = page <= 0 ? 1 : page;

            
            // Should be refactored with advanced searching algorithms
            var postQuery = m_db.Posts.Where(post => post.Title.Contains(keyword) 
                                                     || post.Content.Contains(keyword));

            if (!showPrivate)
            {
                postQuery = postQuery.Where(post => post.Private == false);
            }

            postQuery = postQuery.Skip(10 * pageNo)
                                 .Take(10);

            var postList = postQuery.Select(post => PostListViewModel.Project(post))
                .ToList();
            return View(postList);
        }

        [HttpGet("/Posts/{id}")]
        [HttpGet("/Blog/Posts/Read/{id}")]
        public async Task<ActionResult> Read(int id)
        {
            var post = await m_db.Posts.FirstOrDefaultAsync(post => post.Id == id);

            if (post is null ||
                (!User.Identity.IsAuthenticated && post.Private))
            {
                return NotFound();
            }
            
            if (post.Protected)
            {
                // TODO: Should be replaced with "protected" message
                post.Content = string.Empty;
            }
            
            return View(post);
        }

        [HttpPost("/Posts/{id}")]
        [HttpPost("/Blog/Posts/Read/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReadProtected(int id, string password)
        {
            var passwordHash = CryptoHelper.Sha256(password);
            var post = await m_db.Posts.FirstOrDefaultAsync(post => post.Id == id 
                                                                    && post.ProtectPassword == passwordHash);

            if (post is null)
            {
                return NotFound();
            }

            return View(post);
        }

        [LoginRequired]
        public async Task<ActionResult> Write()
        {
            return View();
        }

        [LoginRequired]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Write([FromBody] PostWriteRequestModel model)
        {
            var postToCreate = model.CreatePostModel();
            var addResult = await m_db.Posts.AddAsync(postToCreate);

            // TODO: define write result model that contains post id to redirect
            if (addResult.State == EntityState.Added)
            {
                return Json(new { success = true, postId = addResult.Entity.Id });
            }

            return Json(new {success = false});
        }
    }
}