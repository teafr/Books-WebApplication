using booksAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace booksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CrudController<TEntity> : BaseController where TEntity : class
    {
        protected readonly ICrudService<TEntity> _service;

        protected CrudController(ICrudService<TEntity> service, ILogger<CrudController<TEntity>> logger) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Get()
        {
            return await ExceptionHandle(async () =>
            {
                var items = await _service.GetAsync();
                return Ok(items);
            });
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _service.GetByIdAsync(id);

                if (user == null)
                {
                    return GetNotFoundResponse();
                }

                return Ok(user);
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public abstract Task<IActionResult> Post(TEntity item);

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public abstract Task<IActionResult> Put(TEntity UserToUpdate);

        [HttpDelete("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var user = await _service.GetByIdAsync(id);

                if (user == null)
                {
                    return GetNotFoundResponse();
                }

                await _service.DeleteAsync(user);
                return NoContent();
            });
        }
    }
}
