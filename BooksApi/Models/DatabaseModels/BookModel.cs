using booksAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace booksAPI.Models.DatabaseModels
{
    public class BookModel
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}