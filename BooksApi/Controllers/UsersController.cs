using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using booksAPI.Data.Identity;
using System.Net.Mime;
using booksAPI.Enums;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IGutendexService gutendexService;
        private readonly IReviewService reviewService;

        public UsersController(UserManager<ApplicationUser> userManager, IGutendexService gutendexService, IReviewService reviewService, ILogger<UsersController> logger) : base(logger)
        {
            this.userManager = userManager;
            this.gutendexService = gutendexService;
            this.reviewService = reviewService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetUserById(string id)
        {
            return await ExceptionHandle(async () =>
            {
                ApplicationUser? user = await userManager.FindByIdAsync(id);
                if (user is null)
                {
                    return NotFound();
                }

                Dictionary<string, int> statusCounts = Enum.GetValues<Status>().ToDictionary(status => status.ToString(), status => user.SavedBooks.Count(b => b.Status == status));

                return user is null ? NotFound() : Ok(new { user.Id, user.UserName, user.Email, user.Name, statusCounts });
            });
        }

        [HttpGet("{id}/savedBooks/{status:int:min(0):max(2)}")]
        public async Task<IActionResult> GetSpecificSavedBooks(string id, int status)
        {
            return await ExceptionHandle(async () =>
            {
                ApplicationUser? user = await userManager.FindByIdAsync(id);
                if (user is null)
                {
                    return NotFound();
                }

                List<int>? ids = user?.SavedBooks.Where(b => b.Status == (Status)status).Select(b => b.BookId).ToList();
                return Ok(ids is null ? [] : await gutendexService.GetBooksByIdsAsync(ids));
            });
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviews(string id)
        {
            return await ExceptionHandle(async () =>
            {
                ApplicationUser? user = await userManager.FindByIdAsync(id);
                return user is null ? NotFound() : Ok(await reviewService.GetReviewsByUserIdAsync(user.Id));
            });
        }
    }
}
