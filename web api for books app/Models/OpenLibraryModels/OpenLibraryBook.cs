using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models.OpenLibraryModels
{
    public class OpenLibraryBook
    {

        [JsonPropertyName("cover_edition_key")]
        public string CoverEditionKey { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string? Subtitle { get; set; }

        //[JsonPropertyName("author_key")]
        //public List<string> AuthorKey { get; set; }

        [JsonPropertyName("author_name")]
        public List<string> AuthorName { get; set; }

        //[JsonPropertyName("cover_i")]
        //public int CoverI { get; set; }

        [JsonPropertyName("first_publish_year")]
        public int FirstPublishYear { get; set; }

        [JsonPropertyName("has_fulltext")]
        public bool HasFullText { get; set; }

        [JsonPropertyName("ia")]
        public List<string> Ia { get; set; }

        //[JsonPropertyName("language")]
        //public List<string> Language { get; set; }
    }

}
