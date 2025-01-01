using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace feedback.Migrations
{
    /// <inheritdoc />
    public partial class test23233 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Default",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormID = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Default", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Default_Form_FormID",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Default_FormID",
                table: "Default",
                column: "FormID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Default");
        }
    }
}
