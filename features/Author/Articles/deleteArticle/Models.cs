using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogApi.features.Author.Articles.deleteArticle
{
    public class DeleteArticleRequest
    {
        public int Id { get; set; }
    }

    public class DeleteArticleResponse
    {
        public string Message { get; set; } = string.Empty;
    }
}