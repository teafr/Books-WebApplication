using booksAPI.Data;
using booksAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace booksAPI.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        [Required, Range(1, 5)]
        public Rate Rating { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        [Required, StringLength(36, MinimumLength = 36)]
        public string ReviewerId { get; set; } = string.Empty;
    }
}
