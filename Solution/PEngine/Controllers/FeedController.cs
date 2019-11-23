using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PEngine.Models.Data;

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
                               .Select(post => new
                               {
                                   post.Id,
                                   post.Title,
                                   updatedAt = post.ModifiedAt == DateTime.MinValue ? post.WrittenAt : post.ModifiedAt,
                                   summary = post.Content.Take(256)
                               })
                               .OrderByDescending(post => post.updatedAt)
                               .ToList();

            return View(feedType, postList);
        }
    }
}