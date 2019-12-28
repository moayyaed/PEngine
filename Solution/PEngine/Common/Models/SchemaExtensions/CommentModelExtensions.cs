using System.Collections.Generic;
using System.Text.Json;
using PEngine.Common.Models.Schema;
using PEngine.Common.Models.SchemaExtensions.Models;

namespace PEngine.Common.Models.SchemaExtensions
{
    using LogList = List<CommentModifyLogModel>;

    public static class CommentModelExtensions
    {
        public static LogList GetModifyLog(this CommentModel model)
        {
            if (model is null)
            {
                return null;
            }

            return JsonSerializer.Deserialize<LogList>(model.ModifyLogJson);
        }

        public static CommentModel AddModifyLog(this CommentModel model, CommentModifyLogModel logModel)
        {
            var currentLog = GetModifyLog(model);
            
            currentLog.Add(logModel);
            model.ModifyLogJson = JsonSerializer.Serialize(currentLog);
            
            return model;
        }
    }
}