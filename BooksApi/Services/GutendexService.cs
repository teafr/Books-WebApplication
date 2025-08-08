using System.Text.Json;
using System.Text.RegularExpressions;
using booksAPI.Models.GutendexModels;

namespace booksAPI.Services
{
    public class GutendexService : IGutendexService
    {
        private readonly HttpClient httpClient;

        private readonly string gutendexUrl;
        private readonly string gutenbergUrl;

        public GutendexService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            gutendexUrl = configuration["Gutendex:Endpoints:Https:GutendexUrl"] ?? throw new JsonException("Couldn't get Gutendex url from application.json file.");
            gutenbergUrl = configuration["Gutendex:Endpoints:Https:GutenbergUrl"] ?? throw new JsonException("Couldn't get Gutenberg url from application.json file.");
        }

        public async Task<SearchResult?> GetAllBooksAsync(string? url = null)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url ?? gutendexUrl);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
        }

        //public async Task<SearchResult?> SearchBooksAsync(string? query, string sort = "popular")
        //{
        //    string url = $"{gutendexUrl}?sort={Uri.EscapeDataString(sort)}&{Uri.EscapeDataString(query ?? "")}";
            
        //    HttpResponseMessage response = await httpClient.GetAsync(url);
        //    response.EnsureSuccessStatusCode();

        //    return JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
        //}

        public async Task<GutendexBook?> GetBookByIdAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{gutendexUrl}{id}");
            response.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<GutendexBook>(await response.Content.ReadAsStringAsync())!;
        }

        public async Task<string?> GetFullTextByBookIdAsync(int id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{gutenbergUrl}{id}/pg{id}.txt").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var text = await response.Content.ReadAsStringAsync();

            var matches = Regex.Matches(text, @"\*{3} (START|END) OF THE PROJECT GUTENBERG EBOOK .+? \*{3}");
            if (matches.Count == 2)
            {
                text = string.Concat(text.Take(new Range(matches[0].Index + matches[0].Value.Length, matches[1].Index - 1)));
            }

            return text.Replace("Progjed Gutenberg EBook", "").Replace("[Illustration]", "").Trim();
        }

        public async Task<List<GutendexBook>?> GetBooksByIdsAsync(List<int> ids)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{gutendexUrl}?ids={string.Join(",", ids)}");
            response.EnsureSuccessStatusCode();

            SearchResult searchResult = JsonSerializer.Deserialize<SearchResult>(await response.Content.ReadAsStringAsync())!;
            return searchResult?.Books;
        }
    }
}
