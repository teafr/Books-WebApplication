using booksAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace booksAPI.Extensions
{
    public static class WebApplicationExtension
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();

            using IdentityContext libraryDbContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();
            using IdentityContext identityDbContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();

            libraryDbContext.Database.Migrate();
            identityDbContext.Database.Migrate();
        }
    }
}
