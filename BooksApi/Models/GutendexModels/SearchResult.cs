using System.Text.Json.Serialization;

namespace booksAPI.Models.GutendexModels
{
    public class SearchResult
    {
        [JsonPropertyName("count")]
        public int CountOfFoundBooks { get; set; }

        [JsonPropertyName("results")]
        public List<GutendexBook>? Books { get; set; }
    }
}
