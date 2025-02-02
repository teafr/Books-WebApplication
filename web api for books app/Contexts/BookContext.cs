using Microsoft.EntityFrameworkCore;
using web_api_for_books_app.Models;

namespace web_api_for_books_app.Contexts;
public class BookContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public BookContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("default")!;

        //Database.EnsureDeletedAsync().Wait();
        //Database.EnsureCreatedAsync().Wait();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BookAndUser> BooksAndUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BookAndUser>().HasNoKey();
    }
}
