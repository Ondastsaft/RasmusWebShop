using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class funkanuordrar2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgsprodukts_Produkter_ProduktId",
                table: "Varukorgsprodukts");

            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgsprodukts_Varukorgar_VarukorgId",
                table: "Varukorgsprodukts");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgId",
                table: "Varukorgsprodukts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProduktId",
                table: "Varukorgsprodukts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgsprodukts_Produkter_ProduktId",
                table: "Varukorgsprodukts",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgsprodukts_Varukorgar_VarukorgId",
                table: "Varukorgsprodukts",
                column: "VarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgsprodukts_Produkter_ProduktId",
                table: "Varukorgsprodukts");

            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgsprodukts_Varukorgar_VarukorgId",
                table: "Varukorgsprodukts");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgId",
                table: "Varukorgsprodukts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProduktId",
                table: "Varukorgsprodukts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgsprodukts_Produkter_ProduktId",
                table: "Varukorgsprodukts",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgsprodukts_Varukorgar_VarukorgId",
                table: "Varukorgsprodukts",
                column: "VarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
