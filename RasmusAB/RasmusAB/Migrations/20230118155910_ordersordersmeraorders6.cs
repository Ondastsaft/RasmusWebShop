using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class ordersordersmeraorders6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "AntalProdukter",
                table: "Varukorgar");

            migrationBuilder.AlterColumn<int>(
                name: "LeverantörId",
                table: "Ordrar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar",
                column: "LeverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar");

            migrationBuilder.AddColumn<int>(
                name: "AntalProdukter",
                table: "Varukorgar",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LeverantörId",
                table: "Ordrar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar",
                column: "LeverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id");
        }
    }
}
