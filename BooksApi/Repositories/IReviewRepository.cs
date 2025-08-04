using booksAPI.Data;

namespace booksAPI.Repositories
{
    public interface IReviewRepository : ICrudRepository<ReviewEntity>
    {
        Task<ICollection<ReviewEntity>> GetReviewsByBookIdAsync(int bookId);
        Task<ICollection<ReviewEntity>> GetReviewsByReviewerIdAsync(string userId);
    }
}