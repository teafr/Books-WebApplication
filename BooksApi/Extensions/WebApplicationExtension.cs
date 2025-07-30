using booksAPI.Contexts;
using booksAPI.Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace booksAPI.Extensions
{
    public static class WebApplicationExtension
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();

            using LibraryContext libraryDbContext = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            using IdentityContext identityDbContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();

            libraryDbContext.Database.Migrate();
            identityDbContext.Database.Migrate();
        }
    }
}
