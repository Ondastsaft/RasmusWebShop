using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class ordersordersmeraorders10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar");

            migrationBuilder.DropIndex(
                name: "IX_Ordrar_LeverantörId",
                table: "Ordrar");

            migrationBuilder.DropColumn(
                name: "LeverantörId",
                table: "Ordrar");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_LeverantörsId",
                table: "Ordrar",
                column: "LeverantörsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörsId",
                table: "Ordrar",
                column: "LeverantörsId",
                principalTable: "Leverantörer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörsId",
                table: "Ordrar");

            migrationBuilder.DropIndex(
                name: "IX_Ordrar_LeverantörsId",
                table: "Ordrar");

            migrationBuilder.AddColumn<int>(
                name: "LeverantörId",
                table: "Ordrar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_LeverantörId",
                table: "Ordrar",
                column: "LeverantörId");

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
