using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class varukorgensprodukter6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduktVarukorg_Produkter_VarukorgensProdukterId",
                table: "ProduktVarukorg");

            migrationBuilder.RenameColumn(
                name: "VarukorgensProdukterId",
                table: "ProduktVarukorg",
                newName: "ProduktersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktVarukorg_Produkter_ProduktersId",
                table: "ProduktVarukorg",
                column: "ProduktersId",
                principalTable: "Produkter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProduktVarukorg_Produkter_ProduktersId",
                table: "ProduktVarukorg");

            migrationBuilder.RenameColumn(
                name: "ProduktersId",
                table: "ProduktVarukorg",
                newName: "VarukorgensProdukterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProduktVarukorg_Produkter_VarukorgensProdukterId",
                table: "ProduktVarukorg",
                column: "VarukorgensProdukterId",
                principalTable: "Produkter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
