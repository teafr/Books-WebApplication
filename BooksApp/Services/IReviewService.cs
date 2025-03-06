using booksAPI.Models.DatabaseModels;

namespace web_api_for_books_app.Services
{
    public interface IReviewService
    {
        Task<Review> CreateAsync(Review review);
        Task DeleteAsync(Review review);
        Task<List<Review>?> GetAsync();
        Task<Review?> GetByIdAsync(int id);
        Task UpdateAsync(Review review);
    }
}