using Microsoft.AspNetCore.Mvc;
using booksAPI.Models.DatabaseModels;
using booksAPI.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : CrudController<User>
    {
        public UsersController(ICrudService<User> service, ILogger<UsersController> logger) : base(service, logger) { }

        public override async Task<IActionResult> Put(User UserToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _service.GetByIdAsync(UserToUpdate.Id);

                if (user == null)
                {
                    return NotFound(recordNotFound);
                }

                user.Name = UserToUpdate.Name;
                user.Email = UserToUpdate.Email!;
                user.Description = UserToUpdate.Description;
                user.Username = UserToUpdate.Username!;
                user.Password = UserToUpdate.Password;

                await _service.UpdateAsync(user);
                return NoContent();
            });
        }
    }
}
