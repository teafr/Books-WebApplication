using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using booksAPI.Repositories;

namespace booksAPI.Repositories
{
    public class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(LibraryContext context) : base(context) { }

        public override async Task<List<Review>?> GetAsync()
        {
            return await dbSet.Include(user => user.User).Include(book => book.Book).ToListAsync();
        }

        public override async Task<Review?> GetByIdAsync(int id)
        {
            return await dbSet.Include(user => user.User).Include(book => book.Book).FirstOrDefaultAsync(item => item.Id == id);
        }
        public override Task<Review> CreateAsync(Review newItem)
        {
            TryToAttachObjects(newItem);
            return base.CreateAsync(newItem);
        }

        public override Task UpdateAsync(Review item)
        {
            TryToAttachObjects(item);
            return base.UpdateAsync(item);
        }

        private void TryToAttachObjects(Review item)
        {
            TryToAttachUser(item);
            TryToAttachBook(item);
        }

        private void TryToAttachUser(Review item)
        {
            if (item.ReviwerId != 0)
            {
                _context.Attach(item.User);
            }
        }

        private void TryToAttachBook(Review item)
        {
            if (item.BookId != 0)
            {
                _context.Attach(item.Book);
            }
        }
    }
}
