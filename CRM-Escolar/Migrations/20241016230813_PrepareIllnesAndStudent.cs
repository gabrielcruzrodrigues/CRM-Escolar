using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Escolar.Migrations
{
    /// <inheritdoc />
    public partial class PrepareIllnesAndStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Illnesses_Students_StudentId",
                table: "Illnesses");

            migrationBuilder.AddColumn<int>(
                name: "IllnessId",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Illnesses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Illnesses_Students_StudentId",
                table: "Illnesses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Illnesses_Students_StudentId",
                table: "Illnesses");

            migrationBuilder.DropColumn(
                name: "IllnessId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Illnesses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Illnesses_Students_StudentId",
                table: "Illnesses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
