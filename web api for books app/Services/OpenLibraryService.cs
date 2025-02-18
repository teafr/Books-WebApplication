using System.Text.Json;
using web_api_for_books_app.Models;

namespace web_api_for_books_app.Services
{
    public class OpenLibraryService : IOpenLibraryService
    {
        private readonly HttpClient _httpClient;

        public OpenLibraryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BookSearchResult> SearchBooksAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"search.json?q={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<BookSearchResult>(await response.Content.ReadAsStringAsync())!;
        }

        public async Task<BookInfo> GetBookDetailsAsync(string editionKey)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"books/{editionKey}.json");
            response.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<BookInfo>(await response.Content.ReadAsStringAsync())!;
        }
    }
}
