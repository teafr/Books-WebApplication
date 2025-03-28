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

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}