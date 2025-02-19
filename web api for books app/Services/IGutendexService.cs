using booksAPI.Models.GutendexModels;

namespace booksAPI.Services
{
    public interface IGutendexService
    {
        Task<List<GutendexBook>> SearchBooksAsync(string key, string value);
        Task<GutendexBook> GetBookByIdAsync(int id);
        Task<string?> GetTxtUrlAsync(int id);

        //Task<SearchResult> GetOrderedBooksAsync(string orderBy);
    }
}