using Microsoft.EntityFrameworkCore;

namespace crud_app_lab3.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite("D:\\books.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData
                (
                new Book() { Id = 1, Title = "AAAA", Author = "BBB", CreatedDate = DateTime.Now, IsAvailable = true },
                new Book() { Id = 2, Title = "BBBB", Author = "CCC", CreatedDate = DateTime.Now, IsAvailable = true },
                new Book() { Id = 3, Title = "CCCC", Author = "DDD", CreatedDate = DateTime.Now, IsAvailable = true },
                new Book() { Id = 4, Title = "DDDD", Author = "EEE", CreatedDate = DateTime.Now, IsAvailable = true }
                );
        }
    }
}
