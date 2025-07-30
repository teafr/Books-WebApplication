using Microsoft.EntityFrameworkCore;
using booksAPI.Data;

namespace booksAPI.Contexts;
public class LibraryContext : DbContext
{
    private readonly string _connectionString;

    public LibraryContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ApplicationDB")!;
    }

    public DbSet<ReviewEntity> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseMySQL(_connectionString);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.Entity<ReviewEntity>().Navigation(r => r.User).AutoInclude();
    //    modelBuilder.Entity<ReviewEntity>().Navigation(r => r.Book).AutoInclude();

    //    modelBuilder.Entity<BookAndUserEntity>().HasOne(book => book.Book).WithMany(b => b.UsersSaved).HasForeignKey(u => u.BookId);
    //    modelBuilder.Entity<BookAndUserEntity>().HasOne(user => user.User).WithMany(u => u.SavedBooks).HasForeignKey(b => b.UserId);
    //}
}
