using booksAPI.Models.GutendexModels;

namespace booksAPI.Services
{
    public interface IGutendexService
    {
        Task<SearchResult?> GetAllBooksAsync(string? url = null);

        //Task<SearchResult?> SearchBooksAsync(string query, string sort = "popular");
        
        Task<GutendexBook?> GetBookByIdAsync(int id);

        Task<List<GutendexBook>?> GetBooksByIdsAsync(List<int> ids);

        Task<string?> GetFullTextByBookIdAsync(int id);    
    }
}