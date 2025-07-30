using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using booksAPI.Data.Identity;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager, ILogger<UsersController> logger) : base(logger)
        {
            this.userManager = userManager;
        }
    }
}
