using Microsoft.EntityFrameworkCore.Migrations;

namespace StackOwerflow.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_Questionid",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "Questionid",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_Questionid",
                table: "Answers",
                column: "Questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_Questionid",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "Questionid",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_Questionid",
                table: "Answers",
                column: "Questionid",
                principalTable: "Questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
