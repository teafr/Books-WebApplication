using System.Text.Json.Serialization;

namespace web_api_for_books_app.Models.GutendexModels
{
    public class Formats
    {
        [JsonPropertyName("text/plain; charset=us-ascii")]
        public string TxtFormat { get; set; }
    }

}
