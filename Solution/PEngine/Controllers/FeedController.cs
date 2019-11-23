using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PEngine.Models.Data;
using PEngine.Models.Feed;

namespace PEngine.Controllers
{
    public class FeedController : Controller
    {
        public FeedController(IHttpContextAccessor context)
        {
            if (context != null)
                context.HttpContext.Response.ContentType = "application/xml";
        }

        [Route("/Feed/{feedType}")]
        public IActionResult DeliverFeed(string feedType)
        {
            if (feedType != "Atom" && feedType != "Rss")
                return NoContent();

            var postList = BlogContextFactory.Context.Posts
                               .Select(post => new FeedEntityModel
                               {
                                   Id = post.Id,
                                   Title = post.Title,
                                   UpdatedAt = post.ModifiedAt == DateTime.MinValue ? post.WrittenAt : post.ModifiedAt,
                                   Summary = post.Content.Take(256).ToString()
                               })
                               .OrderByDescending(post => post.UpdatedAt)
                               .ToList();

            return View(feedType, postList);
        }
    }
}