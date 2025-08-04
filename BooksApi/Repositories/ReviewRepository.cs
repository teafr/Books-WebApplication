using booksAPI.Contexts;
using booksAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace booksAPI.Repositories
{
    public class ReviewRepository : BaseRepository<ReviewEntity>, IReviewRepository
    {
        private readonly LibraryContext context;

        public ReviewRepository(LibraryContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<ReviewEntity>> GetReviewsByBookIdAsync(int bookId)
        {
            return await context.Reviews.Where(r => r.BookId == bookId).ToListAsync();
        }

        public async Task<ICollection<ReviewEntity>> GetReviewsByReviewerIdAsync(string userId)
        {
            return await context.Reviews.Where(r => r.ReviewerId == userId).ToListAsync();
        }
    }
}
