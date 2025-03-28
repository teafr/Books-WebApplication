using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;
using booksAPI.Entities;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : CrudController<User>
    {
        public UsersController(ICrudService<User> service, ILogger<UsersController> logger) : base(service, logger) { }
    }
}
