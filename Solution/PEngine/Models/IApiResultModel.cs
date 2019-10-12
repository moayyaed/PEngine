using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEngine.Models
{
    public enum ApiResult
    {
        success, fail
    }

    public interface IApiResultModel
    {
        public ApiResult Status { get; set; }
        public string    Message { get; set; }
    }
}
