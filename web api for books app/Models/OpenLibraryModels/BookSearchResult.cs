using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models.OpenLibraryModels
{
    public class BookSearchResult
    {
        [JsonPropertyName("numFound")]
        public int NumFound { get; set; }

        [JsonPropertyName("q")]
        public string Query { get; set; }

        [JsonPropertyName("docs")]
        public List<OpenLibraryBook> Books { get; set; }
    }
}
