using booksAPI.Entities;
using booksAPI.Helpers;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

namespace booksAPI.Services
{
    public abstract class AbstractCrudService<TModel, TEntity> : ICrudService<TModel> where TModel : IDatabaseModel where TEntity : IDatabaseEntity
    {
        protected readonly IRepository<TEntity> _repository;

        protected AbstractCrudService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }
        public virtual async Task<List<TModel>?> GetAsync()
        {
            var items = await _repository.GetAsync() ?? [];
            return [.. items.Select(item => GetModelObject(item))];
        }

        public virtual async Task<TModel?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item is null ? default : GetModelObject(item);
        }

        public virtual async Task<TModel> CreateAsync(TModel newItem)
        {
            var createdItem = await _repository.CreateAsync(GetEntityObject(newItem));
            return GetModelObject(createdItem);
        }

        public abstract Task UpdateAsync(TModel itemToUpdate);

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        protected abstract TModel GetModelObject(TEntity entity);

        protected abstract TEntity GetEntityObject(TModel model);
    }
}
