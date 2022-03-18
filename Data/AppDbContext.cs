using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // define table names for your c# models
        public DbSet<Book> Books { get; set; }

    }
}
