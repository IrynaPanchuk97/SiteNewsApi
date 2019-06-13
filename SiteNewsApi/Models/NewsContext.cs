using Microsoft.EntityFrameworkCore;
using SiteNewsApi.Models.Entities;

namespace SiteNewsApi.Models
{
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UsersNews> UsersNews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersNews>()
                .HasKey(a => new { a.IdUser, a.IdNews });

            modelBuilder.Entity<UsersNews>()
                .HasOne(a => a.News)
                .WithMany(b => b.UsersNews)
                .HasForeignKey(a => a.IdNews);

            modelBuilder.Entity<UsersNews>()
                .HasOne(a => a.User)
                .WithMany(b => b.UsersNews)
                .HasForeignKey(a => a.IdUser);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=NewsDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        }
    }
}
