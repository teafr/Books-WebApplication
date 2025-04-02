using booksAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace booksAPI.Models.DatabaseModels
{
    public class BookModel : IDatabaseModel
    {
        public BookModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public BookModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Min 2 and max 20 literals"), Range(2, 20)]
        public string Name { get; set; }
    }
}