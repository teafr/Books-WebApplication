using booksAPI.Entities;
using booksAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace booksAPI.Models
{
    public class ReviewModel
    {
        public ReviewModel(ReviewEntity review)
        {
            Id = review.Id;
            Text = review.Text;
            Rating = review.Rating;
            UserId = review.UserId;
        }

        public int Id { get; set; }

        public string? Text { get; set; }

        [Required, Range(1, 5)]
        public Rate Rating { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
