using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using booksAPI.Models.GutendexModels;

namespace booksAPI.Services
{
    public class GutendexService : IGutendexService
    {
        private readonly HttpClient _httpClient;

        public GutendexService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SearchResult> SearchBooksAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/books?search={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
        }

        public async Task<GutendexBook> FindBookByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/books?ids={id}");
            response.EnsureSuccessStatusCode();

            SearchResult searchResult = JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
            return searchResult.Books[0];
        }

        public async Task<string?> GetFullTextUrlAsync(int id) // in the furure better to make Gutendex argument type
        {
            GutendexBook book = await FindBookByIdAsync(id);

            if (book is null)
            {
                return null;
            }

            return book.Formats.TxtFormat;
        }
    }
}
