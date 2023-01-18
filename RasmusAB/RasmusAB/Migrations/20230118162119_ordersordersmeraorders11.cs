using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class ordersordersmeraorders11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Ordrar_OrderId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_VarukorgsId",
                table: "Ordrar",
                column: "VarukorgsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Varukorgar_VarukorgsId",
                table: "Ordrar",
                column: "VarukorgsId",
                principalTable: "Varukorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Varukorgar_VarukorgsId",
                table: "Ordrar");

            migrationBuilder.DropIndex(
                name: "IX_Ordrar_VarukorgsId",
                table: "Ordrar");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgar_Ordrar_OrderId",
                table: "Varukorgar",
                column: "OrderId",
                principalTable: "Ordrar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
