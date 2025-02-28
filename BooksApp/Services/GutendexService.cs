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

        public async Task<List<GutendexBook>?> SearchBooksAsync(string key, string value)
        {
            string url = $"?{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            SearchResult result = JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
            return result.Books;
        }

        public async Task<GutendexBook?> GetBookByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"?ids={id}");
            response.EnsureSuccessStatusCode();

            SearchResult searchResult = JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
            return searchResult?.Books?.FirstOrDefault();
        }

        public async Task<string?> GetTxtUrlAsync(int id)
        {
            GutendexBook? book = await GetBookByIdAsync(id);
            return book?.Formats?.TxtFormat;
        }
    }
}
