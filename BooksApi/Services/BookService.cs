using booksAPI.Models;
using booksAPI.Models.GutendexModels;

namespace booksAPI.Services
{
    public class BookService : IBookService
    {
        public Task<ICollection<BookModel>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookModel?> GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GutendexBook>?> GetBooksByIdsAsync(List<int> id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<BookModel>> SearchBooksByPatternAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<BookModel>> SearchBooksByTopicAsync(string topic)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<BookModel>> SortBooksAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
