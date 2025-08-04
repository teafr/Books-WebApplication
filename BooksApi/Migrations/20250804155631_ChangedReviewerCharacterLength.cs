using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace booksAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedReviewerCharacterLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "reviewer_id",
                table: "reviews",
                type: "varchar(36)",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldMaxLength: 40);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "reviewer_id",
                table: "reviews",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldMaxLength: 36);
        }
    }
}
