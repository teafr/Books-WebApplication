using web_api_for_books_app.Models.GutendexModels;

namespace web_api_for_books_app.Services
{
    public interface IGutendexService
    {
        Task<SearchResult> SearchBooksAsync(string query);
        Task<GutendexBook> FindBookByIdAsync(int id);
        Task<string?> GetFullTextUrlAsync(int id);
    }
}