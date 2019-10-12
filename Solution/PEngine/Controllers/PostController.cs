using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PEngine.Models.Post;

namespace PEngine.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class PostController : Controller
    {
        private ILogger      m_Logger;
        private HtmlEncoder  m_Encoder;

        public PostController(ILogger _logger, HtmlEncoder _encoder)
        {
            m_Logger  = _logger;
            m_Encoder = _encoder;
        }

        [HttpGet("/{id}")]
        public IActionResult Index(long articleId)
        {
            return RedirectToActionPermanent("Read", PostReadModel.WithId(articleId));
        }

        public Task<IActionResult> List([FromQuery]PostListModel listModel, PostSearchModel searchModel)
        {

        }


        public async Task<IActionResult> Read([FromQuery]PostModel postReadModel)
        {

        }

        public IActionResult Write()
        {
            return View();
        }

        [HttpPut]
        public async Task<bool> Write([FromBody]PostModel postModel)
        {

        }

    }
}