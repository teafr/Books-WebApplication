using Microsoft.EntityFrameworkCore;
using web_api_for_books_app.Models;

namespace web_api_for_books_app.Contexts;
public class LibraryContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public LibraryContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("default")!;
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseMySQL(_connectionString);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //}
}
