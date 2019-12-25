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
        private BlogDbContext m_db;

        public PostsController(BlogDbContext db)
        {
            m_db = db;
        }

        public async Task<ViewResult> List(string searchQuery, int page)
        {
            var postList = m_db.Posts.Select(post => new PostListViewModel());

            if (User is null)
            {
                postList = postList.Where(post => !post.Private);
            }

            // Should be refactored with advanced searching algorithms
            if (searchQuery is null)
            {
                searchQuery = "";
            }
            
            if (page <= 0)
            {
                page = 1;
            }

            postList = postList.Where(post => post.Title.Contains(searchQuery) || post.Content.Contains(searchQuery));
            return View(await postList.ToListAsync());
        }

        [HttpGet("/Posts/{id}")]
        [HttpGet("/Blog/Posts/Read/{id}")]
        public async Task<ActionResult> Read(int id)
        {
            var post = await m_db.Posts.FirstOrDefaultAsync(post => post.Id == id);

            if (post is null ||
                (User is null && post.Private))
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
        public async Task<ActionResult> Write([FromBody] PostWriteRequestModel model)
        {
            var postToCreate = model.CreatePostModel();

            await m_db.Posts.AddAsync(postToCreate);

        }
    }
}