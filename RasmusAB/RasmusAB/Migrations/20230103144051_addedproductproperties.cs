using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class addedproductproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Färg",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Produkter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Namn",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Pris",
                table: "Produkter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Namn",
                table: "Kategorier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Färg",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "Namn",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "Pris",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "Namn",
                table: "Kategorier");
        }
    }
}
