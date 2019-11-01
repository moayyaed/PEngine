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
            throw new NotImplementedException();
        }

        public async Task<CommentWriteResultModel> Write(CommentModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentModifyResultModel> Modify(CommentModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentDeleteResultModel> Delete(CommentDeleteModel deleteModel)
        {
            throw new NotImplementedException();
        }
    }
}