using System.Text.Json.Serialization;

namespace booksAPI.Models.GutendexModels
{
    public class Formats
    {
        [JsonPropertyName("text/plain; charset=us-ascii")]
        public string? TxtFormat { get; set; }

        [JsonPropertyName("image/jpeg")]
        public string? Image { get; set; }
    }

}
