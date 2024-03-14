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
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=finshark_db;Username=postgres;Password=idris2014");
        }
        public override int SaveChanges()
        {
            // Admin password hashing
            foreach (var entry in ChangeTracker.Entries<Admin>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    var user = entry.Entity;
                    if (!string.IsNullOrEmpty(user.PasswordHash) && user.PasswordHash.Length < 50)
                    {
                        user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
                    }
                }
            }

            // Author password hashing
            foreach (var entry in ChangeTracker.Entries<Author>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    var user = entry.Entity;
                    if (!string.IsNullOrEmpty(user.PasswordHash) && user.PasswordHash.Length < 50)
                    {
                        user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
                    }
                }
            }


            return base.SaveChanges();
        }
        public DbSet<Admin> Admins { set; get; }
        public DbSet<Article> Articles { set; get; }
        public DbSet<Author> Authors { set; get; }


    }
}
