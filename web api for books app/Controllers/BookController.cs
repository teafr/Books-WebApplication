using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_for_books_app.Models;
using web_api_for_books_app.Repositories;

namespace web_api_for_books_app.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookRepository bookRepository, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookRepository.GetBooksAsync();
                return Ok(books);
            }
            catch (Exception exeption)
            {
                _logger.LogError(exeption.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        statusCode = 500,
                        message = exeption.Message
                    });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }
                return Ok(book);
            }
            catch (Exception exeption)
            {
                _logger.LogError(exeption.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        statusCode = 500,
                        message = exeption.Message
                    });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            try
            {
                var createdBook = await _bookRepository.CreateBookAsync(book);
                return CreatedAtAction(nameof(AddBook), createdBook);
            }
            catch (Exception exeption)
            {
                _logger.LogError(exeption.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        statusCode = 500,
                        message = exeption.Message
                    });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book bookToUpdate)
        {
            try
            {
                var existingBook = await _bookRepository.GetBookByIdAsync(bookToUpdate.Id);
                if (existingBook == null)
                {
                    return NotFound(new {
                        statusCode=404,
                        message="record not found"
                    });
                }
                existingBook.Id = bookToUpdate.Id;
                existingBook.Name = bookToUpdate.Name;
                existingBook.Author = bookToUpdate.Author;
                existingBook.DateOfPublication = bookToUpdate.DateOfPublication;
                await _bookRepository.UpdateBookAsync(existingBook);
                return NoContent();
            }
            catch (Exception exeption)
            {
                _logger.LogError(exeption.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        statusCode = 500,
                        message = exeption.Message
                    });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var existingBook = await _bookRepository.GetBookByIdAsync(id);
                if (existingBook == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }
                await _bookRepository.DeleteBookAsync(existingBook);
                return NoContent();
            }
            catch (Exception exeption)
            {
                _logger.LogError(exeption.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        statusCode = 500,
                        message = exeption.Message
                    });
            }
        }
    }
}
