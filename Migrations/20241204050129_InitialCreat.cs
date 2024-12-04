using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace feedback.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormEntry_Form_FormId",
                table: "FormEntry");

            migrationBuilder.DropIndex(
                name: "IX_FormEntry_FormId",
                table: "FormEntry");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "FormEntry");

            migrationBuilder.AlterColumn<int>(
                name: "Locale",
                table: "FormEntry",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Locale",
                table: "FormEntry",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "FormEntry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormEntry_FormId",
                table: "FormEntry",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormEntry_Form_FormId",
                table: "FormEntry",
                column: "FormId",
                principalTable: "Form",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
