using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace feedback.Migrations
{
    /// <inheritdoc />
    public partial class Initialoness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Questions9EN",
                table: "Form",
                newName: "Question9EN");

            migrationBuilder.RenameColumn(
                name: "Questions9",
                table: "Form",
                newName: "Question9");

            migrationBuilder.RenameColumn(
                name: "Questions8EN",
                table: "Form",
                newName: "Question8EN");

            migrationBuilder.RenameColumn(
                name: "Questions8",
                table: "Form",
                newName: "Question8");

            migrationBuilder.RenameColumn(
                name: "Questions7EN",
                table: "Form",
                newName: "Question7EN");

            migrationBuilder.RenameColumn(
                name: "Questions7",
                table: "Form",
                newName: "Question7");

            migrationBuilder.RenameColumn(
                name: "Questions6EN",
                table: "Form",
                newName: "Question6EN");

            migrationBuilder.RenameColumn(
                name: "Questions6",
                table: "Form",
                newName: "Question6");

            migrationBuilder.RenameColumn(
                name: "Questions5EN",
                table: "Form",
                newName: "Question5EN");

            migrationBuilder.RenameColumn(
                name: "Questions5",
                table: "Form",
                newName: "Question5");

            migrationBuilder.RenameColumn(
                name: "Questions4EN",
                table: "Form",
                newName: "Question4EN");

            migrationBuilder.RenameColumn(
                name: "Questions4",
                table: "Form",
                newName: "Question4");

            migrationBuilder.RenameColumn(
                name: "Questions3EN",
                table: "Form",
                newName: "Question3EN");

            migrationBuilder.RenameColumn(
                name: "Questions3",
                table: "Form",
                newName: "Question3");

            migrationBuilder.RenameColumn(
                name: "Questions2EN",
                table: "Form",
                newName: "Question2EN");

            migrationBuilder.RenameColumn(
                name: "Questions2",
                table: "Form",
                newName: "Question2");

            migrationBuilder.RenameColumn(
                name: "Questions13EN",
                table: "Form",
                newName: "Question15En");

            migrationBuilder.RenameColumn(
                name: "Questions13",
                table: "Form",
                newName: "Question15");

            migrationBuilder.RenameColumn(
                name: "Questions12EN",
                table: "Form",
                newName: "Question14En");

            migrationBuilder.RenameColumn(
                name: "Questions12",
                table: "Form",
                newName: "Question14");

            migrationBuilder.RenameColumn(
                name: "Questions11EN",
                table: "Form",
                newName: "Question13EN");

            migrationBuilder.RenameColumn(
                name: "Questions11",
                table: "Form",
                newName: "Question13");

            migrationBuilder.RenameColumn(
                name: "Questions10EN",
                table: "Form",
                newName: "Question12EN");

            migrationBuilder.RenameColumn(
                name: "Questions10",
                table: "Form",
                newName: "Question12");

            migrationBuilder.RenameColumn(
                name: "FromTitleEn",
                table: "Form",
                newName: "Question11EN");

            migrationBuilder.RenameColumn(
                name: "FromTitleAr",
                table: "Form",
                newName: "Question11");

            migrationBuilder.RenameColumn(
                name: "FromSectionTwoLabelEn",
                table: "Form",
                newName: "Question10EN");

            migrationBuilder.RenameColumn(
                name: "FromSectionTwoLabelAr",
                table: "Form",
                newName: "Question10");

            migrationBuilder.RenameColumn(
                name: "FromSectionThreeLabelEn",
                table: "Form",
                newName: "FormTitleEn");

            migrationBuilder.RenameColumn(
                name: "FromSectionThreeLabelAr",
                table: "Form",
                newName: "FormTitleAr");

            migrationBuilder.RenameColumn(
                name: "FromSectionOneLabelEn",
                table: "Form",
                newName: "FormSectionTwoLabelEn");

            migrationBuilder.RenameColumn(
                name: "FromSectionOneLabelAr",
                table: "Form",
                newName: "FormSectionTwoLabelAr");

            migrationBuilder.AddColumn<string>(
                name: "FormSectionOneLabelAr",
                table: "Form",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormSectionOneLabelEn",
                table: "Form",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormSectionThreeLabelAr",
                table: "Form",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormSectionThreeLabelEn",
                table: "Form",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormSectionOneLabelAr",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "FormSectionOneLabelEn",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "FormSectionThreeLabelAr",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "FormSectionThreeLabelEn",
                table: "Form");

            migrationBuilder.RenameColumn(
                name: "Question9EN",
                table: "Form",
                newName: "Questions9EN");

            migrationBuilder.RenameColumn(
                name: "Question9",
                table: "Form",
                newName: "Questions9");

            migrationBuilder.RenameColumn(
                name: "Question8EN",
                table: "Form",
                newName: "Questions8EN");

            migrationBuilder.RenameColumn(
                name: "Question8",
                table: "Form",
                newName: "Questions8");

            migrationBuilder.RenameColumn(
                name: "Question7EN",
                table: "Form",
                newName: "Questions7EN");

            migrationBuilder.RenameColumn(
                name: "Question7",
                table: "Form",
                newName: "Questions7");

            migrationBuilder.RenameColumn(
                name: "Question6EN",
                table: "Form",
                newName: "Questions6EN");

            migrationBuilder.RenameColumn(
                name: "Question6",
                table: "Form",
                newName: "Questions6");

            migrationBuilder.RenameColumn(
                name: "Question5EN",
                table: "Form",
                newName: "Questions5EN");

            migrationBuilder.RenameColumn(
                name: "Question5",
                table: "Form",
                newName: "Questions5");

            migrationBuilder.RenameColumn(
                name: "Question4EN",
                table: "Form",
                newName: "Questions4EN");

            migrationBuilder.RenameColumn(
                name: "Question4",
                table: "Form",
                newName: "Questions4");

            migrationBuilder.RenameColumn(
                name: "Question3EN",
                table: "Form",
                newName: "Questions3EN");

            migrationBuilder.RenameColumn(
                name: "Question3",
                table: "Form",
                newName: "Questions3");

            migrationBuilder.RenameColumn(
                name: "Question2EN",
                table: "Form",
                newName: "Questions2EN");

            migrationBuilder.RenameColumn(
                name: "Question2",
                table: "Form",
                newName: "Questions2");

            migrationBuilder.RenameColumn(
                name: "Question15En",
                table: "Form",
                newName: "Questions13EN");

            migrationBuilder.RenameColumn(
                name: "Question15",
                table: "Form",
                newName: "Questions13");

            migrationBuilder.RenameColumn(
                name: "Question14En",
                table: "Form",
                newName: "Questions12EN");

            migrationBuilder.RenameColumn(
                name: "Question14",
                table: "Form",
                newName: "Questions12");

            migrationBuilder.RenameColumn(
                name: "Question13EN",
                table: "Form",
                newName: "Questions11EN");

            migrationBuilder.RenameColumn(
                name: "Question13",
                table: "Form",
                newName: "Questions11");

            migrationBuilder.RenameColumn(
                name: "Question12EN",
                table: "Form",
                newName: "Questions10EN");

            migrationBuilder.RenameColumn(
                name: "Question12",
                table: "Form",
                newName: "Questions10");

            migrationBuilder.RenameColumn(
                name: "Question11EN",
                table: "Form",
                newName: "FromTitleEn");

            migrationBuilder.RenameColumn(
                name: "Question11",
                table: "Form",
                newName: "FromTitleAr");

            migrationBuilder.RenameColumn(
                name: "Question10EN",
                table: "Form",
                newName: "FromSectionTwoLabelEn");

            migrationBuilder.RenameColumn(
                name: "Question10",
                table: "Form",
                newName: "FromSectionTwoLabelAr");

            migrationBuilder.RenameColumn(
                name: "FormTitleEn",
                table: "Form",
                newName: "FromSectionThreeLabelEn");

            migrationBuilder.RenameColumn(
                name: "FormTitleAr",
                table: "Form",
                newName: "FromSectionThreeLabelAr");

            migrationBuilder.RenameColumn(
                name: "FormSectionTwoLabelEn",
                table: "Form",
                newName: "FromSectionOneLabelEn");

            migrationBuilder.RenameColumn(
                name: "FormSectionTwoLabelAr",
                table: "Form",
                newName: "FromSectionOneLabelAr");
        }
    }
}
