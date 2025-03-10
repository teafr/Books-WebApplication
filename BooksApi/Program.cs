using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using booksAPI.Services;
using web_api_for_books_app.DiConteinerInitialization;
using web_api_for_books_app.Services;

namespace booksAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddProblemDetails();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddObjectServices();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDependensies();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
