using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using web_api_for_books_app.Models.GutendexModels;

namespace web_api_for_books_app.Services
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
            return searchResult.results[0];
        }

        public async Task<string?> GetFullTextUrlAsync(string? iaIdentifier)
        {
            return null;
        }
    }
}
