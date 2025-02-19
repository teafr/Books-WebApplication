using booksAPI.Models.GutendexModels;

namespace booksAPI.Services
{
    public interface IGutendexService
    {
        Task<SearchResult> SearchBooksAsync(string query);
        //Task<SearchResult> GetOrderedBooksAsync(string orderBy);
        Task<GutendexBook> FindBookByIdAsync(int id);
        Task<string?> GetFullTextUrlAsync(int id);
    }
}