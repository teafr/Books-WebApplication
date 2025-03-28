using booksAPI.Enums;

namespace booksAPI.Models.DatabaseModels
{
    public class ReviewModel
    {
        public required int Id { get; set; }

        public string? Text { get; set; }

        public required Rate Rating { get; set; }

        public required int UserId { get; set; }

        public required int BookId { get; set; }

        public required BookModel Book { get; set; }

        public required UserModel User { get; set; }
    }
}
