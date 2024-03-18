using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogApi.features.Author.Articles.GetMyArticles
{
    public class ArticleByAuthorRequest
    {
        public int AuthorId { get; set; }
    }

    public class ArticleByAuthorResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}