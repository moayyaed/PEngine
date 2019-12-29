using PEngine.Common.Components.Helpers;
using PEngine.Common.Models.Schema;

namespace PEngine.Modules.Blog.Models.Posts
{
    public static class PostWriteRequestModelExtension
    {
        public static PostModel CreatePostModel(this PostWriteRequestModel model, UserModel user)
        {
            if (string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Content))
            {
                return null;
            }
            
            return new PostModel
            {
                Category = model.Category,
                Title = model.Title,
                
                Writer = user.Id,
                WriterName = user.UserName,
                
                ContentType = model.ContentType,
                ContentCachePath = string.IsNullOrEmpty(model.Content) ?
                    CacheHelper.CachePost(model.ContentType, model.Content) : null,
                Content = model.Content,
                
                Tags = model.Tags,
                Files = model.Files,
                
                Private = model.Private,
                Protected = model.Protected,
                ProtectPassword = model.Protected ?
                    CryptoHelper.Sha256(model.ProtectPassword) : null
            };
        }
    }
}