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
        public List<Author>? Authors { get; set; }

        [JsonPropertyName("summaries")]
        public List<string>? Summaries { get; set; }

        [JsonPropertyName("subjects")]
        public List<string>? Subjects { get; set; }

        [JsonPropertyName("bookshelves")]
        public List<string>? Bookshelves { get; set; }

        [JsonPropertyName("languages")]
        public List<string>? Languages { get; set; }

        [JsonPropertyName("formats")]
        public Formats? Formats { get; set; }

        [JsonPropertyName("copyright")]
        public bool Copyright { get; set; }
        

        //[JsonPropertyName("media_type")]
        //public string MediaType { get; set; }

        //[JsonPropertyName("translators")]
        //public List<Translator> Translators { get; set; }
    }

}
