using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class orderfiiiin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Produkter_ProduktId",
                table: "Varukorgar");

            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgsprodukts_Varukorgar_VarukorgId",
                table: "Varukorgsprodukts");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_ProduktId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Varukorgar");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgId",
                table: "Varukorgsprodukts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgsprodukts_Varukorgar_VarukorgId",
                table: "Varukorgsprodukts",
                column: "VarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "Varukorgar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_ProduktId",
                table: "Varukorgar",
                column: "ProduktId");

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgar_Produkter_ProduktId",
                table: "Varukorgar",
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
    }
}
