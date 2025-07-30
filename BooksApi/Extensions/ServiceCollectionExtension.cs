using booksAPI.Contexts;
using booksAPI.Data;
using booksAPI.Data.Identity;
using booksAPI.Repositories;
using booksAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace booksAPI.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependensies(this IServiceCollection services)
        {
            services.AddScoped<IRepository<ReviewEntity>, ReviewRepository>();

            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<IdentityContext>().AddApiEndpoints();

            services.AddDbContext<LibraryContext>();
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("IdentityDB")!);
            });

            services.AddHttpClient<IGutendexService, GutendexService>();

            return services;
        }
    }
}
