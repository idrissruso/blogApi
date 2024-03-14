using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace blogApi.data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasKey(a => a.Id);
            modelBuilder.Entity<Article>().HasKey(a => a.Id);
            modelBuilder.Entity<Author>().HasKey(a => a.Id);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Admin> Admins { set; get; }
        public DbSet<Article> Articles { set; get; }
        public DbSet<Author> Authors { set; get; }


    }
}
