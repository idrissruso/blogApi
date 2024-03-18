using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogApi.features.Author.Articles.SaveArticle
{
    public class NewArticleRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }

    public class NewArticleResponse
    {
        public int StatsCode { get; set; } = 200;

        public string Status { get; set; } = "Success";

        public string Message { get; set; } = string.Empty;
    }

}