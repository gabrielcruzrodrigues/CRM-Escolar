using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Escolar.Migrations
{
    /// <inheritdoc />
    public partial class ConfigRelationshipBetweenStudentAndResponsible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsibleStudent");

            migrationBuilder.AddColumn<int>(
                name: "ResponsibleId",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ResponsibleId",
                table: "Students",
                column: "ResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Responsibles_ResponsibleId",
                table: "Students",
                column: "ResponsibleId",
                principalTable: "Responsibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Responsibles_ResponsibleId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ResponsibleId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ResponsibleId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "ResponsibleStudent",
                columns: table => new
                {
                    ResponsiblesId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsibleStudent", x => new { x.ResponsiblesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ResponsibleStudent_Responsibles_ResponsiblesId",
                        column: x => x.ResponsiblesId,
                        principalTable: "Responsibles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsibleStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsibleStudent_StudentsId",
                table: "ResponsibleStudent",
                column: "StudentsId");
        }
    }
}
