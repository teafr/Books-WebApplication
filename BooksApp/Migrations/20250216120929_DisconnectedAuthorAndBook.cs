using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace booksAPI.Migrations
{
    /// <inheritdoc />
    public partial class DisconnectedAuthorAndBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_authors_author_id",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_author_id",
                table: "books");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_books_author_id",
                table: "books",
                column: "author_id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_authors_author_id",
                table: "books",
                column: "author_id",
                principalTable: "authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
