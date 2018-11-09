using Microsoft.EntityFrameworkCore.Migrations;

namespace StackUnderflow.Data.Migrations
{
    public partial class AddedMarkAsDeletedToResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MarkAsDeleted",
                table: "Responses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarkAsDeleted",
                table: "Responses");
        }
    }
}
