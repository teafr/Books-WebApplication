using booksAPI.Data;
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
            UserId = review.ReviewerId;
        }

        public int Id { get; set; }

        public string? Text { get; set; }

        [Required, Range(1, 5)]
        public Rate Rating { get; set; }

        [Required, StringLength(40)]
        public string UserId { get; set; }
    }
}
