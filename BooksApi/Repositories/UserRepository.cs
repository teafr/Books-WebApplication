using Microsoft.EntityFrameworkCore;
using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using web_api_for_books_app.Repositories;

namespace booksAPI.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(LibraryContext context) : base(context) { }

        public override async Task<List<User>?> GetAsync()
        {
            return await dbSet.ToListAsync();
        }
    }
}
