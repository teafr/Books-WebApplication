using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using booksAPI.Services;
using web_api_for_books_app.Services;

namespace web_api_for_books_app.DiConteinerInitialization
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
            services.AddTransient<IReviewService, ReviewService>();
            services.AddHttpClient<IGutendexService, GutendexService>(client =>
            {
                client.BaseAddress = new Uri("https://gutendex.com/books");
            });

            return services;
        }
    }
}
