using booksAPI.Data;
using booksAPI.Extensions;
using booksAPI.Models;
using booksAPI.Repositories;
using System.Reflection;

namespace booksAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository repository;

        public ReviewService(IReviewRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ReviewModel>?> GetAllReviewsAsync()
        {
            var reviews = await repository.GetAsync();
            return reviews?.Select(review => review.ConvertToModel()).ToList();
        }

        public async Task<ReviewModel?> GetReviewByIdAsync(int reviewId)
        {
            var reviewEntity = await repository.GetByIdAsync(reviewId);
            return reviewEntity?.ConvertToModel();
        }

        public async Task<ICollection<ReviewModel>> GetReviewsByBookIdAsync(int bookId)
        {
            var reviews = await repository.GetReviewsByBookIdAsync(bookId);
            return reviews.Select(review => review.ConvertToModel()).ToList();
        }

        public async Task<ICollection<ReviewModel>> GetReviewsByUserIdAsync(string userId)
        {
            ArgumentNullException.ThrowIfNull(userId);
            //if (string.IsNullOrEmpty(userId) || userId.Length != 36)
            //{
            //    throw new ArgumentException("User ID cannot be null or has to be 36 characters long.", nameof(userId));
            //}

            var reviews = await repository.GetReviewsByReviewerIdAsync(userId);
            return reviews.Select(review => review.ConvertToModel()).ToList();
        }

        public async Task<ReviewModel> AddReviewAsync(int bookId, ReviewModel review)
        {
            ArgumentNullException.ThrowIfNull(review);
            return (await repository.CreateAsync(review.ConvertToEntity(bookId))).ConvertToModel();
        }

        public async Task UpdateReviewAsync(ReviewModel review)
        {
            ArgumentNullException.ThrowIfNull(review);

            ReviewEntity existingReview = (await repository.GetByIdAsync(review.Id)) ?? throw new KeyNotFoundException($"Review with ID {review.Id} not found.");
            ReviewEntity reviewToUpdate = review.ConvertToEntity(existingReview.BookId);
            
            PropertyInfo[] propertiesInfo = typeof(ReviewEntity).GetProperties();
            Array.ForEach(propertiesInfo, propertyInfo => propertyInfo.SetValue(existingReview, propertyInfo.GetValue(reviewToUpdate)));
            
            await repository.UpdateAsync(existingReview);
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            var existingReview = (await repository.GetByIdAsync(reviewId)) ?? throw new KeyNotFoundException($"Review with ID {reviewId} not found.");
            await repository.DeleteAsync(existingReview);
        }
    }
}
