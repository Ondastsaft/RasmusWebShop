using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class ordersordersmeraorders7 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Leverantörer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leverantörer_OrderId",
                table: "Leverantörer",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leverantörer_Ordrar_OrderId",
                table: "Leverantörer",
                column: "OrderId",
                principalTable: "Ordrar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leverantörer_Ordrar_OrderId",
                table: "Leverantörer");

            migrationBuilder.DropIndex(
                name: "IX_Leverantörer_OrderId",
                table: "Leverantörer");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Leverantörer");

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
