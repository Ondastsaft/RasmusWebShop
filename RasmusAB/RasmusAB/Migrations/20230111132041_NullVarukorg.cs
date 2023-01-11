using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class NullVarukorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Användare_Varukorgar_MinVarukorgId",
                table: "Användare");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgsId",
                table: "Användare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MinVarukorgId",
                table: "Användare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Användare_Varukorgar_MinVarukorgId",
                table: "Användare",
                column: "MinVarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Användare_Varukorgar_MinVarukorgId",
                table: "Användare");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgsId",
                table: "Användare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinVarukorgId",
                table: "Användare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Användare_Varukorgar_MinVarukorgId",
                table: "Användare",
                column: "MinVarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
