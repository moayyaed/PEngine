using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PEngine.Models.Post;
using PEngine.Models.Search;

namespace PEngine.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class PostController : Controller
    {
        private readonly HtmlEncoder  m_Encoder;

        public PostController(HtmlEncoder _encoder)
        {
            m_Encoder = _encoder;
        }

        [HttpGet("/{id}")]
        public IActionResult Index(long articleId)
        {
            return RedirectToActionPermanent("Read", PostReadModel.WithId(articleId));
        }

        public async Task<ViewResult> List([FromQuery]PostListRequestModel request)
        {
            return View();
        }


        public async Task<IActionResult> Read([FromQuery]PostModel postReadModel)
        {
            return View();
        }

        public IActionResult Write()
        {
            return View();
        }

        [HttpPut]
        public async Task<bool> Write([FromBody]PostModel postModel)
        {
            return false;
        }

    }
}