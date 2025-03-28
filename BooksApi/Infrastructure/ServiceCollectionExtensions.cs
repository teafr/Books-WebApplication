using booksAPI.Contexts;
using booksAPI.Entities;
using booksAPI.Repositories;
using booksAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace booksAPI.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependensies(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>();
            services.AddTransient<IRepository<Book>, BookRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Review>, ReviewRepository>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICrudService<Review>, ReviewService>();
            services.AddTransient<ICrudService<User>, UserService>();
            services.AddTransient<ICrudService<Book>, BookService>();
            services.AddHttpClient<IGutendexService, GutendexService>(client =>
            {
                string url = configuration["Gutendex:Endpoints:Https:Url"]!;
                ArgumentNullException.ThrowIfNull(url);
                client.BaseAddress = new Uri(url);
            });

            return services;
        }
    }
}
