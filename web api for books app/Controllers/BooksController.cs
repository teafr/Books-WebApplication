using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using booksAPI.Models.DatabaseModels;
using booksAPI.Models.GutendexModels;
using booksAPI.Repositories;
using booksAPI.Services;
using web_api_for_books_app.Controllers;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IGutendexService _gutendexService;

        public BooksController(IRepository<Book> bookRepository, ILogger<BooksController> logger, IGutendexService gutendexService) : base(logger)
        {
            _bookRepository = bookRepository;
            _gutendexService = gutendexService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks([FromQuery] string query)
        {
            List<GutendexBook>? books = await _gutendexService.SearchBooksAsync("search", query);

            if (books == null)
            {
                return NotFound(recordNotFound);
            }

            return Ok(books);
        }

        [HttpGet("{id}/fulltext")]
        public async Task<IActionResult> GetFullText(int id)
        {
            return await ExceptionHandle(async () =>
            {
                string? txtUrl = await _gutendexService.GetTxtUrlAsync(id);

                if (txtUrl == null)
                {
                    return NotFound(recordNotFound);
                }

                return Ok(new { txtUrl });
            });            
        }




        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var books = await _bookRepository.GetAsync();
                return Ok(books);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var book = await _bookRepository.GetByIdAsync(id);

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
                Book createdBook = await _bookRepository.CreateAsync(book);
                return CreatedAtAction(nameof(Post), createdBook);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(Book bookToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var existingBook = await _bookRepository.GetByIdAsync(bookToUpdate.Id);

                if (existingBook == null)
                {
                    return NotFound(recordNotFound);
                }

                existingBook.Id = bookToUpdate.Id;
                existingBook.Name = bookToUpdate.Name;

                await _bookRepository.UpdateAsync(existingBook);
                return NoContent();
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var existingBook = await _bookRepository.GetByIdAsync(id);

                if (existingBook == null)
                {
                    return NotFound(recordNotFound);
                }

                await _bookRepository.DeleteAsync(existingBook);
                return NoContent();
            });
        }
    }
}
