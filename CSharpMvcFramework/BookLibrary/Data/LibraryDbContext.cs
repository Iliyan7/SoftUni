using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<BookBorrower> BookBorrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookBorrower>()
                .HasOne(bb => bb.Book)
                .WithMany(b => b.BookBorrowers)
                .HasForeignKey(bb => bb.BookId);

            modelBuilder.Entity<BookBorrower>()
               .HasOne(bb => bb.Borrower)
               .WithMany(b => b.BookBorrowers)
               .HasForeignKey(bb => bb.BorrowerId);
        }
    }
}
