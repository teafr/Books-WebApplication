namespace web_api_for_books_app.Models.GutendexModels
{
    public class SearchResult
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<GutendexBook> results { get; set; }
    }
}
