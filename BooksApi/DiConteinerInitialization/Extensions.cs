using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using booksAPI.Services;

namespace booksAPI.DiConteinerInitialization
{
    public static class Extensions
    {
        public static IServiceCollection AddDependensies(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>();
            services.AddTransient<IRepository<Book>, BookRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Review>, ReviewRepository>();

            return services;
        }

        public static IServiceCollection AddObjectServices(this IServiceCollection services)
        {
            services.AddTransient<ICrudService<Review>, ReviewService>();
            services.AddTransient<ICrudService<User>, UserService>();
            services.AddHttpClient<IGutendexService, GutendexService>(client =>
            {
                client.BaseAddress = new Uri("https://gutendex.com/books");
            });

            return services;
        }
    }
}
