using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PEngine.Models.Comment;

namespace PEngine.Controllers
{
    [ApiController] 
    [AutoValidateAntiforgeryToken]
    public class CommentController : Controller
    {
        public async Task<List<CommentModel>> List(CommentListModel listModel)
        {

        }

        public async Task<CommentWriteResultModel> Write(CommentModel model)
        {

        }

        public async Task<CommentModifyResultModel> Modify(CommentModel model)
        {

        }

        public async Task<CommentDeleteResultModel> Delete(CommentDeleteModel deleteModel)
        {

        }
    }
}