using Microsoft.EntityFrameworkCore;
using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;

namespace booksAPI.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        private readonly LibraryContext _context;
        public ReviewRepository(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        public async Task<Review> CreateAsync(Review newReview)
        {
            await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();
            return newReview;
        }

        public async Task DeleteAsync(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }
    }
}
