using booksAPI.Repositories;
using System.Reflection;

namespace booksAPI.Services
{
    public abstract class AbstractCrudService<TModel, TEntity>
    {
        //protected readonly IRepository<TEntity> _repository;

        //protected AbstractCrudService(IRepository<TEntity> repository)
        //{
        //    _repository = repository;
        //}

        //public virtual async Task UpdateAsync(TEntity entityToUpdate)
        //{
        //    var existingEntity = await _repository.GetByIdAsync(entityToUpdate.Id);

        //    PropertyInfo[] propertiesInfo = typeof(TEntity).GetProperties();
        //    Array.ForEach(propertiesInfo, propertyInfo => propertyInfo.SetValue(existingEntity, propertyInfo.GetValue(entityToUpdate)));
        //}
    }
}
