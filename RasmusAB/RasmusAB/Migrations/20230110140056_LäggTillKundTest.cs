using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class LäggTillKundTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VarukorgsId",
                table: "Användare");

            migrationBuilder.RenameColumn(
                name: "varukorgsId",
                table: "Användare",
                newName: "VarukorgsId");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgsId",
                table: "Användare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VarukorgsId",
                table: "Användare",
                newName: "varukorgsId");

            migrationBuilder.AlterColumn<int>(
                name: "varukorgsId",
                table: "Användare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VarukorgsId",
                table: "Användare",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
