using DatabaseModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DatabaseModel
{
    public class MainDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Intermediate Tables

            #region Books_Authors

            modelBuilder.Entity<Book>().HasMany(r => r.Authors).WithMany(a => a.Books)
                .UsingEntity<Dictionary<string, object>>("Books_Authors",
                    j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientCascade));

            #endregion

            #region Books_Categories

            modelBuilder.Entity<Book>().HasMany(r => r.Categories).WithMany(a => a.Books)
                .UsingEntity<Dictionary<string, object>>("Books_Categories",
                    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientCascade),
                    j => j.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientCascade));

            #endregion

  
            #endregion
        }


    }
}