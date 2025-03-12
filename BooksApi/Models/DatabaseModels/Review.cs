using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using booksAPI.Enums;

namespace booksAPI.Models.DatabaseModels
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        [Column("id")]
        public required int Id { get; set; }

        [Column("text")]
        public string? Text { get; set; }

        [Column("rating")]
        [Range(1, 5)]
        public required Rate Rating { get; set; }

        [Column("reviewer_id")]
        [ForeignKey("User")]
        public required int ReviwerId { get; set; }

        [Column("book_id")]
        [ForeignKey("Book")]
        public required int BookId { get; set; }

        public required User User { get; set; }

        public required Book Book { get; set; }
    }
}
