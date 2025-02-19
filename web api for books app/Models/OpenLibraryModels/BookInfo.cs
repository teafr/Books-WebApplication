using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models.OpenLibraryModels
{
    public class BookInfo
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("source_records")]
        public List<string> SourceRecords { get; set; }

        [JsonPropertyName("ocaid")]
        public string Ocaid { get; set; }
    }
}
