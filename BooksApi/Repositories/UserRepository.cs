using booksAPI.Contexts;
using booksAPI.Entities;

namespace booksAPI.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(LibraryContext context) : base(context) { }
    }
}
