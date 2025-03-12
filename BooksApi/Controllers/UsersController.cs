using Microsoft.AspNetCore.Mvc;
using booksAPI.Models.DatabaseModels;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : CrudController<User>
    {
        public UsersController(ICrudService<User> service, ILogger<UsersController> logger) : base(service, logger) { }

        public override async Task<IActionResult> Post(User user)
        {
            return await ExceptionHandle(async () =>
            {
                if (user is null)
                {
                    return GetBadRequestResponse();
                }

                if (user.Username is null && user.Email is null && user.Name is null)
                {
                    return GetUnprocessableEntityResponse();
                }

                var createdUser = await _service.CreateAsync(user);
                return CreatedAtAction(nameof(Post), createdUser);
            });
        }

        public override async Task<IActionResult> Put(User UserToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                if (UserToUpdate is null)
                {
                    return GetBadRequestResponse();
                }

                if (UserToUpdate.Username is null && UserToUpdate.Email is null && UserToUpdate.Name is null)
                {
                    return GetUnprocessableEntityResponse();
                }

                var user = await _service.GetByIdAsync(UserToUpdate.Id);

                if (user == null)
                {
                    return GetNotFoundResponse();
                }

                user.Name = UserToUpdate.Name;
                user.Email = UserToUpdate.Email!;
                user.Description = UserToUpdate.Description;
                user.Username = UserToUpdate.Username!;

                await _service.UpdateAsync(user);
                return NoContent();
            });
        }
    }
}
