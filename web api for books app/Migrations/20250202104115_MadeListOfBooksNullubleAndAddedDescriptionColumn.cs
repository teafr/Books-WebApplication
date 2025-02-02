using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api_for_books_app.Migrations
{
    /// <inheritdoc />
    public partial class MadeListOfBooksNullubleAndAddedDescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "users",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "users");
        }
    }
}
