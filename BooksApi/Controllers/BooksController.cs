using Microsoft.AspNetCore.Mvc;
using booksAPI.Models.DatabaseModels;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly ICrudService<Book> _repository;

        public BooksController(ICrudService<Book> repository, ILogger<BooksController> logger) : base(logger)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var books = await _repository.GetAsync();
                return Ok(books);
            });
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var book = await _repository.GetByIdAsync(id);

                if (book == null)
                {
                    return GetNotFoundResponse();
                }

                return Ok(book);
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(Book book)
        {
            return await ExceptionHandle(async () =>
            {
                if (book is null)
                {
                    return GetBadRequestResponse();
                }

                var createdBook = await _repository.CreateAsync(book);
                return CreatedAtAction(nameof(Post), createdBook);
            });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Put(Book bookToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                if (bookToUpdate is null)
                {
                    return GetBadRequestResponse();
                }

                if (bookToUpdate.Name is null)
                {
                    return GetUnprocessableEntityResponse();
                }

                var existingBook = await _repository.GetByIdAsync(bookToUpdate.Id);

                if (existingBook == null)
                {
                    return GetNotFoundResponse();
                }

                existingBook.Id = bookToUpdate.Id;
                existingBook.Name = bookToUpdate.Name;

                await _repository.UpdateAsync(existingBook);
                return NoContent();
            });
        }

        [HttpDelete("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var existingBook = await _repository.GetByIdAsync(id);

                if (existingBook == null)
                {
                    return GetNotFoundResponse();
                }

                await _repository.DeleteAsync(existingBook);
                return NoContent();
            });
        }
    }
}
