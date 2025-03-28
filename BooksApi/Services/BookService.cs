using booksAPI.Entities;
using booksAPI.Models.DatabaseModels;
using booksAPI.Repositories;

namespace booksAPI.Services
{
    public class BookService : AbstractCrudService<BookModel, Book>
    {
        public BookService(IRepository<Book> repository) : base(repository) { }

        public override async Task UpdateAsync(BookModel bookToUpdate)
        {
            var existingBook = await _repository.GetByIdAsync(bookToUpdate.Id);

            existingBook!.Id = bookToUpdate.Id;
            existingBook.Name = bookToUpdate.Name;

            await _repository.UpdateAsync(existingBook);
        }

        protected override Book GetEntityObject(BookModel model)
        {
            return new Book { Id = model.Id, Name = model.Name };
        }

        protected override BookModel GetModelObject(Book entity)
        {
            return new BookModel(entity.Id, entity.Name);
        }
    }
}
