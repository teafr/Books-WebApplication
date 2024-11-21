using web_api_for_books_app.Enums;

namespace web_api_for_books_app.Models
{
    public class Review
    {
        // I'll add new tables in future
        public int Id { get; set; }
        public Book Book { get; set; }
        public string TextOfReview { get; set; }
        public Reviewer Reviewer { get; set; }
        public Rate Rating { get; set; }
    }
}
