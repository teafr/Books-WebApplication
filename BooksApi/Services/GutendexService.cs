using System.Text.Json;
using System.Text.RegularExpressions;
using booksAPI.Models.GutendexModels;

namespace booksAPI.Services
{
    public class GutendexService : IGutendexService
    {
        private readonly HttpClient _httpClient;

        private readonly string gutendexUrl;
        private readonly string gutenbergUrl;

        public GutendexService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            gutendexUrl = configuration["Gutendex:Endpoints:Https:GutendexUrl"];
            gutenbergUrl = configuration["Gutendex:Endpoints:Https:GutenbergUrl"];
        }

        public async Task<List<GutendexBook>?> SearchBooksAsync(string key, string value)
        {
            string url = $"{gutendexUrl}?{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            SearchResult result = JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
            return result.Books;
        }

        public async Task<GutendexBook?> GetBookByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{gutendexUrl}?ids={id}");
            response.EnsureSuccessStatusCode();

            SearchResult searchResult = JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
            return searchResult?.Books?.FirstOrDefault();
        }

        public async Task<string?> GetFullTextByBookIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{gutenbergUrl}{id}/pg{id}.txt").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var text = await response.Content.ReadAsStringAsync();

            var matches = Regex.Matches(text, @"\*{3} (START|END) OF THE PROJECT GUTENBERG EBOOK .+? \*{3}");
            if (matches.Count == 2)
            {                
                text = string.Concat(text.Take(new Range(matches[0].Index + matches[0].Value.Length, matches[1].Index - 1)));
            }

            return text;
        }
    }
}
