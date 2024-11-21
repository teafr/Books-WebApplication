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
        _connectionString = _configuration.GetConnectionString("default");
    }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_connectionString);
    }
}
