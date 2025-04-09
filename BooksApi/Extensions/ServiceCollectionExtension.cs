using booksAPI.Contexts;
using booksAPI.Entities;
using booksAPI.Models;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using booksAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace booksAPI.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependensies(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Book>, BookRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Review>, ReviewRepository>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityCore<LoginUser>().AddEntityFrameworkStores<IdentityContext>().AddApiEndpoints();
            services.AddDbContext<LibraryContext>();
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("IdentityDB")!);
            });

            services.AddTransient<ICrudService<ReviewModel>, ReviewService>();
            services.AddTransient<ICrudService<UserModel>, UserService>();
            services.AddTransient<ICrudService<BookModel>, BookService>();
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
