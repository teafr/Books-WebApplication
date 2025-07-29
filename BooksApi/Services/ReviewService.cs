using booksAPI.Models;

namespace booksAPI.Services
{
    public class ReviewService : IReviewService
    {
        public Task<ReviewModel> AddReviewAsync(int bookId, ReviewModel review)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReviewAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewModel?> GetReviewByIdAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ReviewModel>> GetReviewsByBookIdAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ReviewModel>> GetReviewsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReviewAsync(int reviewId, ReviewModel review)
        {
            throw new NotImplementedException();
        }
    }
}
