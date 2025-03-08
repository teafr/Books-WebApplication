using Microsoft.AspNetCore.Mvc;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;
using booksAPI.Controllers;
using web_api_for_books_app.Services;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly ICrudService<User> _repository;

        public UsersController(ICrudService<User> repository, ILogger<UsersController> logger) : base(logger)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var users = await _repository.GetAsync();
                return Ok(users);
            });
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _repository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound(recordNotFound);
                }

                return Ok(user);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            return await ExceptionHandle(async () =>
            {
                if (user is null)
                {
                    return BadRequest(badRequest);
                }

                var createdUser = await _repository.CreateAsync(user);
                return CreatedAtAction(nameof(Post), createdUser);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put(User UserToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                if (UserToUpdate is null)
                {
                    return BadRequest(badRequest);
                }

                var user = await _repository.GetByIdAsync(UserToUpdate.Id);

                if (user == null)
                {
                    return NotFound(recordNotFound);
                }

                user.Name = UserToUpdate.Name;
                user.Email = UserToUpdate.Email;
                user.Description = UserToUpdate.Description;
                user.Username = UserToUpdate.Username;

                await _repository.UpdateAsync(user);
                return NoContent();
            });
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _repository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound(recordNotFound);
                }

                await _repository.DeleteAsync(user);
                return NoContent();
            });
        }
    }
}
