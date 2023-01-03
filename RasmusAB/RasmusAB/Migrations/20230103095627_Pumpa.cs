using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class Pumpa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ánvändare",
                table: "Ánvändare");

            migrationBuilder.RenameTable(
                name: "Ánvändare",
                newName: "Användare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Användare",
                table: "Användare",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Användare",
                table: "Användare");

            migrationBuilder.RenameTable(
                name: "Användare",
                newName: "Ánvändare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ánvändare",
                table: "Ánvändare",
                column: "Id");
        }
    }
}
