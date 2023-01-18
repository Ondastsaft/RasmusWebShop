using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class ordersordersmeraorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar");

            migrationBuilder.RenameColumn(
                name: "LeverantörId",
                table: "Ordrar",
                newName: "leverantörId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordrar_LeverantörId",
                table: "Ordrar",
                newName: "IX_Ordrar_leverantörId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Leverantörer_leverantörId",
                table: "Ordrar",
                column: "leverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Leverantörer_leverantörId",
                table: "Ordrar");

            migrationBuilder.RenameColumn(
                name: "leverantörId",
                table: "Ordrar",
                newName: "LeverantörId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordrar_leverantörId",
                table: "Ordrar",
                newName: "IX_Ordrar_LeverantörId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar",
                column: "LeverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
