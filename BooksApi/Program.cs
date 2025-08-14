using booksAPI.Data.Identity;
using booksAPI.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace booksAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
            {
                EnvironmentName = Environments.Development,
                Args = args
            });

            builder.Services.AddProblemDetails();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

            builder.Services.ConfigureServices(builder.Configuration).AddDependensies();
            builder.Services.AddCors();

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

            app.MapGet("user/me", async (ClaimsPrincipal claims, IdentityContext context) =>
            {
                var userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                return await context.Users.FindAsync(userId);
            });

            app.UseStatusCodePages();
            app.UseHttpsRedirection();

            app.UseCors(app => app.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.MapIdentityApi<ApplicationUser>();
            app.MapControllers();

            app.MapPost("/logout", (SignInManager<ApplicationUser> signInManager) =>
            {
                return signInManager.SignOutAsync();
            }).RequireAuthorization();

            app.Run();
        }
    }
}
