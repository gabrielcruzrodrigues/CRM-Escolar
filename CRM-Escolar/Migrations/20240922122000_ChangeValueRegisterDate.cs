using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Escolar.Migrations
{
    /// <inheritdoc />
    public partial class ChangeValueRegisterDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "RegisterDate",
                table: "Students",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
