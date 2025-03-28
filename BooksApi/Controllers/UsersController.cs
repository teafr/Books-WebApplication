using Microsoft.AspNetCore.Mvc;
using booksAPI.Services;
using booksAPI.Entities;
using booksAPI.Models.DatabaseModels;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : CrudController<UserModel>
    {
        public UsersController(ICrudService<UserModel> service, ILogger<UsersController> logger) : base(service, logger) { }
    }
}
