using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Escolar.Migrations
{
    /// <inheritdoc />
    public partial class ChangeICollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Students_StudentId",
                table: "Medications");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Medications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Students_StudentId",
                table: "Medications",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Students_StudentId",
                table: "Medications");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Medications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Students_StudentId",
                table: "Medications",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
