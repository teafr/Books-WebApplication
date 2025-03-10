using booksAPI.Models.DatabaseModels;
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

        public async Task<Book> CreateAsync(Book review)
        {
            return await _bookRepository.CreateAsync(review);
        }

        public async Task UpdateAsync(Book review)
        {
            await _bookRepository.UpdateAsync(review);
        }

        public async Task DeleteAsync(Book review)
        {
            await _bookRepository.DeleteAsync(review);
        }
    }
}
