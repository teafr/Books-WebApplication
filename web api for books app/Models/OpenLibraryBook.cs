using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models
{
    public class OpenLibraryBook
    {
        [JsonPropertyName("author_key")]
        public string[] AuthorKey { get; set; }

        [JsonPropertyName("author_name")]
        public string[] AuthorName { get; set; }

        [JsonPropertyName("cover_edition_key")]
        public string CoverEditionKey { get; set; }

        [JsonPropertyName("cover_i")]
        public int CoverI { get; set; }

        [JsonPropertyName("first_publish_year")]
        public int FirstPublishYear { get; set; }

        [JsonPropertyName("has_fulltext")]
        public bool HasFullText { get; set; }

        [JsonPropertyName("ia")]
        public string[] Ia { get; set; }

        [JsonPropertyName("ia_collection_s")]
        public string IaCollections { get; set; }

        [JsonPropertyName("language")]
        public string[] Language { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }
    }

}
