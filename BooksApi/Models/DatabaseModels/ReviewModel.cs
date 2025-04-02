using booksAPI.Entities;
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

        public ReviewModel(Review review)
        {
            Id = review.Id;
            Text = review.Text;
            Rating = review.Rating;
            Book = new BookModel(review.Book);
            User = new UserModel(review.User);
        }

        [Required]
        public int Id { get; set; }

        public string? Text { get; set; }

        [Required, Range(1, 5)]
        public Rate Rating { get; set; }

        [Required]
        public BookModel Book { get; set; }

        [Required]
        public UserModel User { get; set; }
    }
}
