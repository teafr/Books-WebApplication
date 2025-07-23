using booksAPI.Contexts;
using booksAPI.Entities;
using booksAPI.Models;
using booksAPI.Models.DatabaseModels;
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
            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Review>, ReviewRepository>();

            services.AddScoped<ICrudService<ReviewModel>, ReviewService>();
            services.AddScoped<ICrudService<UserModel>, UserService>();
            services.AddScoped<ICrudService<BookModel>, BookService>();

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

            services.AddHttpClient<IGutendexService, GutendexService>(
            //    client =>
            //{
            //    string url = configuration["Gutendex:Endpoints:Https:Url"]!;
            //    ArgumentNullException.ThrowIfNull(url);
            //    client.BaseAddress = new Uri(url);
            //}
            );

            return services;
        }
    }
}
