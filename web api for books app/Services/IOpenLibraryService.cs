using web_api_for_books_app.Models;

namespace web_api_for_books_app.Services
{
    public interface IOpenLibraryService
    {
        Task<BookInfo> GetBookDetailsAsync(string editionKey);
        Task<BookSearchResult> SearchBooksAsync(string query);
    }
}