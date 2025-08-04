using booksAPI.Data;
using booksAPI.Models;

namespace booksAPI.Extensions
{
    public static class ModelsExtension
    {
        public static ReviewEntity ConvertToEntity(this ReviewModel review, int bookId)
        {
            return new ReviewEntity()
            {
                Id = review.Id,
                Text = review.Text,
                Rating = review.Rating,
                BookId = bookId,
                ReviewerId = review.ReviewerId,
                ReviewDate = review.ReviewDate,
            };
        }

        public static ReviewModel ConvertToModel(this ReviewEntity review)
        {
            return new ReviewModel()
            {
                Id = review.Id,
                Text = review.Text,
                Rating = review.Rating,
                ReviewerId = review.ReviewerId,
                ReviewDate = review.ReviewDate,
            };
        }
    }
}
