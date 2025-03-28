using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;
using booksAPI.Entities;
using booksAPI.Models.DatabaseModels;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : CrudController<BookModel>
    {
        public BooksController(ICrudService<BookModel> service, ILogger<BooksController> logger) : base(service, logger) { }
    }
}
