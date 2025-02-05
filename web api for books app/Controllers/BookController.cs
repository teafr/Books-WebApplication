using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_for_books_app.Models;
using web_api_for_books_app.Repositories;

namespace web_api_for_books_app.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(IRepository<Book> bookRepository, IRepository<Author> authorRepository, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var books = await _bookRepository.GetAsync();
                return Ok(books);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
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

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            try
            {
                if (book.Author == null && book.AuthorId != 0)
                {
                    Author author = await _authorRepository.GetByIdAsync(book.AuthorId);

                    if (author == null)
                    {
                        return NotFound(new
                        {
                            statusCode = 404,
                            message = "author not found by id"
                        });
                    }

                    book.Author = author;
                }

                Book createdBook = await _bookRepository.CreateAsync(book);
                return CreatedAtAction(nameof(Post), createdBook);
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

        [HttpPut]
        public async Task<IActionResult> Put(Book bookToUpdate)
        {
            try
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
                existingBook.AuthorId = bookToUpdate.AuthorId;

                await _bookRepository.UpdateAsync(existingBook);
                return NoContent();
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
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
