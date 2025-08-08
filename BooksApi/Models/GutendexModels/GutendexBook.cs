using System.Text.Json.Serialization;

namespace booksAPI.Models.GutendexModels
{
    public class GutendexBook
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("authors")]
        public ICollection<Author>? Authors { get; set; }

        [JsonPropertyName("summaries")]
        public ICollection<string>? Summaries { get; set; }

        [JsonPropertyName("subjects")]
        public ICollection<string>? Subjects { get; set; }

        [JsonPropertyName("bookshelves")]
        public ICollection<string>? Bookshelves { get; set; }

        [JsonPropertyName("languages")]
        public ICollection<string>? Languages { get; set; }

        [JsonPropertyName("formats")]
        public Formats? Formats { get; set; }

        //[JsonPropertyName("copyright")]
        //public bool Copyright { get; set; }

        //[JsonPropertyName("translators")]
        //public List<Translator> Translators { get; set; }
    }
}
