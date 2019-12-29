using System;
using System.Linq;
using PEngine.Common.Components.Helpers;
using PEngine.Common.Models.Schema;
using PEngine.Modules.Blog.Models.Posts;

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
        
        public static PostModel UpdatePost(this PostModel model, PostWriteRequestModel source)
        {
            model.Title = source.Title;
            model.Category = source.Category;
            
            model.ContentType = source.ContentType;
            model.Content = source.Content;
            model.ContentCachePath = CacheHelper.Cachemodel(source.ContentType, source.Content);

            model.Private = source.Private;
            model.Protected = source.Protected;
            model.ProtectPassword = CryptoHelper.Sha256(source.ProtectPassword);

            model.Tags = source.Tags;
            model.Files = source.Files;
            
            model.ModifiedAt = DateTime.UtcNow;

            return model;
        }
    }
}