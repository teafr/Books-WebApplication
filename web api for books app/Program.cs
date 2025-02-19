using web_api_for_books_app.Contexts;
using web_api_for_books_app.Models.DatabaseModels;
using web_api_for_books_app.Repositories;
using web_api_for_books_app.Services;

namespace web_api_for_books_app
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<LibraryContext>();
            builder.Services.AddTransient<IRepository<Book>, BookRepository>();
            builder.Services.AddTransient<IRepository<User>, UserRepository>();
            builder.Services.AddHttpClient<IOpenLibraryService, OpenLibraryService>(client =>
            {
                client.BaseAddress = new Uri("https://openlibrary.org/");
            });
            builder.Services.AddHttpClient<IBookService, BookService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
