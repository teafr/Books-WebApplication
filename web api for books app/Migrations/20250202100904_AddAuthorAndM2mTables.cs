using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace web_api_for_books_app.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorAndM2mTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "author",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    full_name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_authors_author_id",
                table: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropIndex(
                name: "IX_books_author_id",
                table: "books");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "books");

            migrationBuilder.AddColumn<string>(
                name: "author",
                table: "books",
                type: "longtext",
                nullable: false);
        }
    }
}
