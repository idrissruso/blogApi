using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace blogApi.data
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=blog_db;Username=postgres;Password=idris2014");
        }

        public DbSet<Admin> Admins { set; get; }
        public DbSet<ArticleEntity> Articles { set; get; }
        public DbSet<AuthorEntity> Authors { set; get; }


    }
}
