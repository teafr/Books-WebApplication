using web_api_for_books_app.Models.GutendexModels;

namespace web_api_for_books_app.Services
{
    public interface IGutendexService
    {
        Task<GutendexBook> FindBookByIdAsync(int id);
        Task<string?> GetFullTextUrlAsync(string? iaIdentifier);
        Task<SearchResult> SearchBooksAsync(string query);
    }
}