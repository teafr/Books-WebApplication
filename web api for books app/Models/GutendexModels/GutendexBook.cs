namespace web_api_for_books_app.Models.GutendexModels
{
    public class GutendexBook
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<Author> authors { get; set; }
        public List<string> summaries { get; set; }
        public List<Translator> translators { get; set; }
        public List<string> subjects { get; set; }
        public List<string> bookshelves { get; set; }
        public List<string> languages { get; set; }
        public bool copyright { get; set; }
        public string media_type { get; set; }
        public Formats formats { get; set; }
    }

}
