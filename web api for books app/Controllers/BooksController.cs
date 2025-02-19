using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_for_books_app.Models.DatabaseModels;
using web_api_for_books_app.Models.OpenLibraryModels;
using web_api_for_books_app.Repositories;
using web_api_for_books_app.Services;

namespace web_api_for_books_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly ILogger<BooksController> _logger;
        private readonly IOpenLibraryService _openLibraryService;
        private readonly IBookService _bookService;
        private const string NO_FULL_TEXT_MESSAGE = "Full text not available for this book.";

        public BooksController(IRepository<Book> bookRepository, ILogger<BooksController> logger, IOpenLibraryService openLibraryService, IBookService bookService)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _openLibraryService = openLibraryService;
            _bookService = bookService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks([FromQuery] string query)
        {
            BookSearchResult searchResult = await _openLibraryService.SearchBooksAsync(query);
            List<OpenLibraryBook> books = searchResult.Books.Where(b => b.HasFullText).ToList();

            return Ok(books);
        }

        [HttpGet("{iaIdentifier}/fulltext")]
        public async Task<IActionResult> GetFullText(string iaIdentifier)
        {
            return await ExceptionHandle(async () =>
            {
                if (iaIdentifier == null)
                {
                    return NotFound(NO_FULL_TEXT_MESSAGE);
                }

                var fullTextUrl = await _openLibraryService.GetFullTextUrlAsync(iaIdentifier);

                if (fullTextUrl is null)
                {
                    return NotFound(NO_FULL_TEXT_MESSAGE);
                }

                string text = await _bookService.GetBookTextAsync(fullTextUrl);
                return Ok(new { text });
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
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
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
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
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
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }

                await _bookRepository.DeleteAsync(existingBook);
                return NoContent();
            });
        }

        private async Task<IActionResult> ExceptionHandle(Func<Task<IActionResult>> function)
        {
            try
            {
                return await function();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    statusCode = 500,
                    message = exception.Message
                });
            }
        }
    }
}
