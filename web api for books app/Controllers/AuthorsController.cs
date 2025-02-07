using Microsoft.AspNetCore.Mvc;
using web_api_for_books_app.Models;
using web_api_for_books_app.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_for_books_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IRepository<Author> authorRepository, ILogger<AuthorsController> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var authors = await _authorRepository.GetAsync();
                return Ok(authors);
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
                var author = await _authorRepository.GetByIdAsync(id);

                if (author == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }

                return Ok(author);
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
        public async Task<IActionResult> Post(Author author)
        {
            try
            {
                var createdAuthor = await _authorRepository.CreateAsync(author);
                return CreatedAtAction(nameof(Post), createdAuthor);
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
        public async Task<IActionResult> Put(Author authorToUpdate)
        {
            try
            {
                var author = await _authorRepository.GetByIdAsync(authorToUpdate.Id);

                if (author == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }

                author.Name = authorToUpdate.Name;
                // books????????

                await _authorRepository.UpdateAsync(author);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var author = await _authorRepository.GetByIdAsync(id);

                if (author == null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = "record not found"
                    });
                }

                await _authorRepository.DeleteAsync(author);
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
