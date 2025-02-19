using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using web_api_for_books_app.Models.OpenLibraryModels;

namespace web_api_for_books_app.Services
{
    public class OpenLibraryService : IOpenLibraryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _archiveDomain;

        public OpenLibraryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _archiveDomain = "https://archive.org";
        }

        public async Task<BookSearchResult> SearchBooksAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"search.json?q={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<BookSearchResult>(await response.Content.ReadAsStringAsync())!;
        }

        public async Task<string?> GetFullTextUrlAsync(string? iaIdentifier)
        {
            if (string.IsNullOrEmpty(iaIdentifier) || string.IsNullOrWhiteSpace(iaIdentifier))
            {
                return null;
            }

            string metadataUrl = $"{_archiveDomain}/metadata/{iaIdentifier}";

            HttpResponseMessage response = await _httpClient.GetAsync(metadataUrl);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            using JsonDocument jsonDocument = JsonDocument.Parse(content);
            JsonElement root = jsonDocument.RootElement;

            if (root.TryGetProperty("files", out JsonElement files))
            {
                foreach (var file in files.EnumerateArray())
                {
                    if (file.TryGetProperty("name", out JsonElement fileName))
                    {
                        string name = fileName.GetString()!;

                        if (name.EndsWith(".txt"))
                        {
                            string url = $"{_archiveDomain}/download/{iaIdentifier}/{name}";
                            return url;
                        }
                    }
                }
            }

            return null;
        }

        //public async Task<BookInfo> GetBookDetailsAsync(string editionKey)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync($"books/{editionKey}.json");
        //    response.EnsureSuccessStatusCode();

        //    return JsonSerializer.Deserialize<BookInfo>(await response.Content.ReadAsStringAsync())!;
        //}
    }
}
