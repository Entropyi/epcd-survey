using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace feedback.Migrations
{
    /// <inheritdoc />
    public partial class InitialCr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scale11",
                table: "FormEntry");

            migrationBuilder.DropColumn(
                name: "Scale12",
                table: "FormEntry");

            migrationBuilder.DropColumn(
                name: "Scale13",
                table: "FormEntry");

            migrationBuilder.DropColumn(
                name: "Questions14",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Questions14EN",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Questions15",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Questions15EN",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Questions16",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Questions16EN",
                table: "Form");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Scale11",
                table: "FormEntry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Scale12",
                table: "FormEntry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Scale13",
                table: "FormEntry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Questions14",
                table: "Form",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questions14EN",
                table: "Form",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questions15",
                table: "Form",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questions15EN",
                table: "Form",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questions16",
                table: "Form",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questions16EN",
                table: "Form",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
