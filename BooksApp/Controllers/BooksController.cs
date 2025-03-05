using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using booksAPI.Models.DatabaseModels;
using booksAPI.Models.GutendexModels;
using booksAPI.Repositories;
using booksAPI.Services;
using booksAPI.Controllers;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly IRepository<Book> _repository;

        public BooksController(IRepository<Book> repository, ILogger<BooksController> logger) : base(logger)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var books = await _repository.GetAsync();
                return Ok(books);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var book = await _repository.GetByIdAsync(id);

                if (book == null)
                {
                    return NotFound(recordNotFound);
                }

                return Ok(book);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            return await ExceptionHandle(async () =>
            {
                var createdBook = await _repository.CreateAsync(book);
                return CreatedAtAction(nameof(Post), createdBook);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Book bookToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var existingBook = await _repository.GetByIdAsync(bookToUpdate.Id);

                if (existingBook == null)
                {
                    return NotFound(recordNotFound);
                }

                existingBook.Id = bookToUpdate.Id;
                existingBook.Name = bookToUpdate.Name;

                await _repository.UpdateAsync(existingBook);
                return NoContent();
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var existingBook = await _repository.GetByIdAsync(id);

                if (existingBook == null)
                {
                    return NotFound(recordNotFound);
                }

                await _repository.DeleteAsync(existingBook);
                return NoContent();
            });
        }
    }
}
