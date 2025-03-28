using booksAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace booksAPI.Models.DatabaseModels
{
    public class ReviewModel : IDatabaseModel
    {
        public ReviewModel(int id, string? text, Rate rating, BookModel book, UserModel user)
        {
            Id = id;
            Text = text;
            Rating = rating;
            Book = book;
            User = user;
        }

        [Required]
        public int Id { get; set; }

        public string? Text { get; set; }

        [Required]
        [Range(1, 5)]
        public Rate Rating { get; set; }

        [Required]
        public BookModel Book { get; set; }

        [Required]
        public UserModel User { get; set; }
    }
}
