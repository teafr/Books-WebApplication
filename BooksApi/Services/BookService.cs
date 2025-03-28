using booksAPI.Entities;
using booksAPI.Repositories;

namespace booksAPI.Services
{
    public class BookService : ICrudService<Book>
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>?> GetAsync()
        {
            return await _bookRepository.GetAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            return await _bookRepository.CreateAsync(book);
        }

        public async Task UpdateAsync(Book existingBook)
        {
            await _bookRepository.UpdateAsync(existingBook);
        }

        public async Task DeleteAsync(Book book)
        {
            await _bookRepository.DeleteAsync(book);
        }
    }
}
