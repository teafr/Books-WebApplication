using Microsoft.EntityFrameworkCore;
using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using web_api_for_books_app.Repositories;

namespace booksAPI.Repositories
{
    public class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(LibraryContext context) : base(context) { }

        public override async Task<List<Review>?> GetAsync()
        {
            return await dbSet.ToListAsync();
        }
    }
}
