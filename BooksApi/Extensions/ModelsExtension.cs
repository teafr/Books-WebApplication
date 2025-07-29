using booksAPI.Entities;
using booksAPI.Models;

namespace booksAPI.Extensions
{
    public static class ModelsExtension
    {
        public static ReviewEntity ConvertToEntity(this ReviewModel review, int bookId, string userId)
        {
            return new ReviewEntity()
            {
                Id = review.Id,
                Text = review.Text,
                Rating = review.Rating,
                BookId = bookId,
                UserId = userId
            };
        }
    }
}
