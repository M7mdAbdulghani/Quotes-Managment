using Microsoft.EntityFrameworkCore;
using QuotesManagement.Core;

namespace QuotesManagement.Data
{
    public class QuotesManagementDbContext : DbContext
    {

        public QuotesManagementDbContext(DbContextOptions<QuotesManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Mohamed",
                    LastName = "Abdulghani"
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Diya",
                    LastName = "Abdulghani"
                }
            );
        }
    }
}
