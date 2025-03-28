using booksAPI.Entities;
using booksAPI.Models.DatabaseModels;

namespace booksAPI.Services
{
    public interface ICrudService<TModel> where TModel : IDatabaseModel
    {
        Task<List<TModel>?> GetAsync();
        Task<TModel?> GetByIdAsync(int id);
        Task<TModel> CreateAsync(TModel newItem);
        Task DeleteAsync(int id);
        Task UpdateAsync(TModel itemToUpdate);
    }
}