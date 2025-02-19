using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models.OpenLibraryModels
{
    public class File
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("mtime")]
        public string Mtime { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; }
    }

}
