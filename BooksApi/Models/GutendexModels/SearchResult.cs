using System.Text.Json.Serialization;

namespace booksAPI.Models.GutendexModels
{
    public class SearchResult
    {
        [JsonPropertyName("count")]
        public int CountOfBooks { get; set; }

        [JsonPropertyName("next")]
        public string? NextPageUrl { get; set; }

        [JsonPropertyName("previous")]
        public string? PreviousPageUrl { get; set; }

        [JsonPropertyName("results")]
        public List<GutendexBook>? Books { get; set; }
    }
}
