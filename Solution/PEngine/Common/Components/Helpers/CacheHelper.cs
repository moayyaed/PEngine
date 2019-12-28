using System;
using System.IO;
using HeyRed.MarkdownSharp;

namespace PEngine.Common.Components.Helpers
{
    public static class CacheHelper
    {
        public static string CachePost(string contentType, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
         
            string cacheData;

            switch (contentType)
            {
                case "markdown":
                    cacheData = CacheMarkdown(content);
                    break;
                  
                default:
                    return null;
            }
            
            
            var path = $"~/Repositories/PostCaches/{contentType}/{Path.GetRandomFileName()}";
            File.WriteAllText(path, cacheData);

            return path;
        }

        private static string CacheMarkdown(string markdown)
        {
            return new Markdown().Transform(markdown);
        }
    }
}