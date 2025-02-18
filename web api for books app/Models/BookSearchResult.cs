using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models
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

    public class BookInfo
    {
        public string title { get; set; }
        public string[] publishers { get; set; }
        public string publish_date { get; set; }
        public string key { get; set; }
        public string subtitle { get; set; }
        public int[] covers { get; set; }
        public string[] source_records { get; set; }
        public string ocaid { get; set; }
    }
}
