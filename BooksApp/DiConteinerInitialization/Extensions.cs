using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

namespace web_api_for_books_app.DiConteinerInitialization
{
    public static class Extensions
    {
        public static IServiceCollection AddDependensies(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Book>, BookRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Review>, ReviewRepository>();

            return services;
        }
    }
}
