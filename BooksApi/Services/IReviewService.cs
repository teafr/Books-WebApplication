using booksAPI.Models;

namespace booksAPI.Services
{
    public interface IReviewService
    {
        /// <summary>
        /// Gets review by its ID.
        /// </summary>
        /// <param name="reviewId">The ID of the review.</param>
        /// <returns></returns>
        Task<ReviewModel?> GetReviewByIdAsync(int reviewId);

        /// <summary>
        /// Gets all reviews for a specific book.
        /// </summary>
        /// <param name="bookId">The ID of the book.</param>
        /// <returns>A collection of reviews for the specified book.</returns>
        Task<ICollection<ReviewModel>> GetReviewsByBookIdAsync(int bookId);

        /// <summary>
        /// Gets all reviews for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A collection of reviews for the specified user.</returns>
        Task<ICollection<ReviewModel>> GetReviewsByUserIdAsync(string userId);

        /// <summary>
        /// Adds a review to a book.
        /// </summary>
        /// <param name="bookId">The ID of the book to review.</param>
        /// <param name="review">The review to add.</param>
        /// <returns>The added review.</returns>
        Task<ReviewModel> AddReviewAsync(int bookId, ReviewModel review);

        /// <summary>
        /// Updates an existing review.
        /// </summary>
        /// <param name="reviewId">The ID of the review.</param>
        /// <param name="review">The review to update.</param>
        /// <returns>True if operation successfull.</returns>
        Task<bool> UpdateReviewAsync(int reviewId, ReviewModel review);

        /// <summary>
        /// Deletes a review by its ID.
        /// </summary>
        /// <param name="reviewId">The ID of the review to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<bool> DeleteReviewAsync(int reviewId);

    }
}
