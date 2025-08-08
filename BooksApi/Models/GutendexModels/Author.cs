using System.Text.Json.Serialization;

namespace booksAPI.Models.GutendexModels
{
    public class Author
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
