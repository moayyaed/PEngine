﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models.Comment
{
    public class CommentDeleteResultModel : IApiResultModel
    {
        public ApiResult Status { get; set; }
        public string Message { get; set; }
    }
}
