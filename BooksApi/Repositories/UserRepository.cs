using Microsoft.EntityFrameworkCore;
using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

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
