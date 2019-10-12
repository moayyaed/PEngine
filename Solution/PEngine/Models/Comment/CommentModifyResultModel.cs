using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Comment
{
    public class CommentModifyResultModel : IApiResultModel
    {
        public ApiResult Status { get; set; }
        public string Message { get; set; }
    }
}
