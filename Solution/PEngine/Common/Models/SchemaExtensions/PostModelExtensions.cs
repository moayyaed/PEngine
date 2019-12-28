using System;
using System.Linq;
using PEngine.Common.Models.Schema;

namespace PEngine.Common.Models.SchemaExtensions
{
    public static class PostModelExtensions
    {
        public static string[] GetTagList(this PostModel model)
        {
            return string.IsNullOrEmpty(model.Tags) ? model.Tags.Split(",") : Array.Empty<string>();
        }

        public static Guid[] GetFileList(this PostModel model)
        {
            return string.IsNullOrEmpty(model.Files) ? model.Files.Split(',')
                .Select(fileId => new Guid(fileId))
                .ToArray() : Array.Empty<Guid>();
        }

        public static string Exerpt(this PostModel model, int length)
        {
            return new string(
                model.Content.Substring(0, length)
                    .Where(c => !char.IsSymbol(c))
                    .ToArray()
            );
        }
    }
}