
namespace web_api_for_books_app.Services
{
    public interface IBookService
    {
        Task<string> GetBookTextAsync(string fullTextUrl);
    }
}