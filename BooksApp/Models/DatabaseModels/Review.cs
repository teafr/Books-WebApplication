using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using booksAPI.Enums;

namespace booksAPI.Models.DatabaseModels
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("text")]
        public string? Text { get; set; }

        [Column("rating")]
        [Required]
        public Rate Rating { get; set; }

        [Column("reviewer_id")]
        [ForeignKey("User")]
        public required int ReviwerId { get; set; }

        [Column("book_id")]
        [ForeignKey("Book")]
        [Required]
        public int BookId { get; set; }

        public required User User { get; set; }

        public required Book Book { get; set; }
    }
}
