using web_api_for_books_app.Models.OpenLibraryModels;

namespace web_api_for_books_app.Services
{
    public interface IOpenLibraryService
    {
        Task<BookSearchResult> SearchBooksAsync(string query);
        Task<string?> GetFullTextUrlAsync(string iaIdentifier);

        Task<BookInfo> GetBookDetailsAsync(string editionKey);
    }
}