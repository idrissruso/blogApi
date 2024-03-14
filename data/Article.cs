using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace blogApi.data
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;


        public string Content { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Author Author { get; set; } = new Author();

    }
}