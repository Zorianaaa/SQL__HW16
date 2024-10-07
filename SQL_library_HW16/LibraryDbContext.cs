using System.Data.Entity;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace SQL_library_HW16
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
            : base(ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString)
        {
        }

        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .HasRequired(l => l.Reader)
                .WithMany()
                .HasForeignKey(l => l.ReaderId);

            modelBuilder.Entity<Loan>()
                .HasRequired(l => l.Book)
                .WithMany()
                .HasForeignKey(l => l.BookId);
        }
    }
}
