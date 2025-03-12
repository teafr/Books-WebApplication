using Microsoft.AspNetCore.Mvc;
using booksAPI.Models.DatabaseModels;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : CrudController<Book>
    {
        public BooksController(ICrudService<Book> service, ILogger<BooksController> logger) : base(service, logger) { }

        public override async Task<IActionResult> Post(Book book)
        {
            return await ExceptionHandle(async () =>
            {
                if (book is null)
                {
                    return GetBadRequestResponse();
                }

                var createdBook = await _service.CreateAsync(book);
                return CreatedAtAction(nameof(Post), createdBook);
            });
        }

        public override async Task<IActionResult> Put(Book bookToUpdate)
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

                var existingBook = await _service.GetByIdAsync(bookToUpdate.Id);

                if (existingBook == null)
                {
                    return GetNotFoundResponse();
                }

                existingBook.Id = bookToUpdate.Id;
                existingBook.Name = bookToUpdate.Name;

                await _service.UpdateAsync(existingBook);
                return NoContent();
            });
        }
    }
}
