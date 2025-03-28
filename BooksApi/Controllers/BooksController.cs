using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;
using booksAPI.Entities;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : CrudController<Book>
    {
        public BooksController(ICrudService<Book> service, ILogger<BooksController> logger) : base(service, logger) { }
    }
}
