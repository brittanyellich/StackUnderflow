using Microsoft.EntityFrameworkCore.Migrations;

namespace StackUnderflow.Data.Migrations
{
    public partial class MadeThingsMoreInappropriate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Responses",
                newName: "Inappropriate");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Questions",
                newName: "Inappropriate");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Comments",
                newName: "Inappropriate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inappropriate",
                table: "Responses",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Inappropriate",
                table: "Questions",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Inappropriate",
                table: "Comments",
                newName: "IsActive");
        }
    }
}
