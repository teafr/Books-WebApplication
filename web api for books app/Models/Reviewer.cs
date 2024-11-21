namespace web_api_for_books_app.Models
{
    public class Reviewer
    {
        // I'll add new tables in future
        public int Id { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
