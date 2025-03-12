using booksAPI.Contexts;
using booksAPI.Models.DatabaseModels;

namespace booksAPI.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(LibraryContext context) : base(context) { }
    }
}
