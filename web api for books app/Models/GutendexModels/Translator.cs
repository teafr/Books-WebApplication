using System.Text.Json.Serialization;

namespace booksAPI.Models.GutendexModels
{
    public class Translator
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

}
