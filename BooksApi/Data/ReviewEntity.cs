using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using booksAPI.Enums;

namespace booksAPI.Data
{
    [Table("reviews")]
    public class ReviewEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("text")]
        public string? Text { get; set; }

        [Column("rating")]
        [Required, Range(1, 5)]
        public Rate Rating { get; set; }

        public DateTime ReviewDate { get; set; }

        [Column("reviewer_id")]
        [Required, StringLength(36, MinimumLength = 36)]
        public string ReviewerId { get; set; } = string.Empty;

        [Column("book_id")]
        public int BookId { get; set; }
    }
}
