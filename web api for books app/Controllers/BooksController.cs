using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_for_books_app.Models;
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

        public BooksController(IRepository<Book> bookRepository, ILogger<BooksController> logger, IOpenLibraryService openLibraryService)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _openLibraryService = openLibraryService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var results = await _openLibraryService.SearchBooksAsync(query);
            return Ok(results);
        }

        [HttpGet("{editionKey}/fulltext")]
        public async Task<IActionResult> GetFullText(string editionKey)
        {
            return await ExceptionHandle(async () =>
            {
                BookInfo bookDetails = await _openLibraryService.GetBookDetailsAsync(editionKey);

                if (bookDetails == null || bookDetails.source_records == null || !bookDetails.source_records.Any())
                {
                    return NotFound("Full text not available for this book.");
                }

                var iaIdentifier = bookDetails.source_records[0];
                var fullTextUrl = $"https://archive.org/download/{iaIdentifier}/{iaIdentifier}.txt";

                // You could also implement logic to verify that the URL exists or support multiple formats.
                return Ok(new { fullTextUrl });
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
