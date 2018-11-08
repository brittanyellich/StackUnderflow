using Microsoft.EntityFrameworkCore.Migrations;

namespace StackUnderflow.Data.Migrations
{
    public partial class ChangingCommentResponseRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_QuestionId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Responses_ResponseId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Comments_QuestionId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ResponseId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Responses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResponseId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Responses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ResponseId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuestionId",
                table: "Responses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_QuestionId",
                table: "Comments",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ResponseId",
                table: "Comments",
                column: "ResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_QuestionId",
                table: "Comments",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Responses_ResponseId",
                table: "Comments",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Questions_QuestionId",
                table: "Responses",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
