using booksAPI.Models.DatabaseModels;
using booksAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace booksAPI.Controllers
{
    public abstract class CrudController<TEntity> : BaseController where TEntity : IDatabaseModel
    {
        protected readonly ICrudService<TEntity> _service;

        protected CrudController(ICrudService<TEntity> service, ILogger<CrudController<TEntity>> logger) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json)]
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
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var item = await _service.GetByIdAsync(id);
                return item is null ? NotFound(recordNotFound) : Ok(item);
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        [Produces(MediaTypeNames.Application.Json)]
        public virtual async Task<IActionResult> Post(TEntity item)
        {
            return await ExceptionHandle(async () =>
            {
                var createdItem = await _service.CreateAsync(item);
                return CreatedAtAction(nameof(Post), createdItem);
            });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status415UnsupportedMediaType)]
        public virtual async Task<IActionResult> Put(TEntity itemToUpdate)
        {
            return await ExceptionHandle(async () =>
            {
                var existingItem = await _service.GetByIdAsync(itemToUpdate.Id);

                if (existingItem is null)
                {
                    return NotFound(recordNotFound);
                }

                var itemProperties = typeof(TEntity).GetProperties();
                if (itemProperties != null)
                {
                    foreach (var property in itemProperties)
                    {
                        property.SetValue(existingItem, property.GetValue(itemToUpdate));
                    }
                }

                await _service.UpdateAsync(existingItem);
                return NoContent();
            });
        }

        [HttpDelete("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            return await ExceptionHandle(async () =>
            {
                var item = await _service.GetByIdAsync(id);

                if (item is null)
                {
                    return NotFound(recordNotFound);
                }

                await _service.DeleteAsync(item);
                return NoContent();
            });
        }
    }
}
