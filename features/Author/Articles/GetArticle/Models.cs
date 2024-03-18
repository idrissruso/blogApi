using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogApi.features.Author.Articles.GetArticle
{
    public class GetArticleByIdRequest
    {
        public int Id { get; set; }
    }

    public class GetArticleByIdResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}