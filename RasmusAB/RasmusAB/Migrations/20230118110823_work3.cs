using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class work3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Ordrar_OrderId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Varukorgar",
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
                name: "FK_Varukorgar_Ordrar_OrderId",
                table: "Varukorgar",
                column: "OrderId",
                principalTable: "Ordrar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Ordrar_OrderId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Varukorgar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_OrderId",
                table: "Varukorgar",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgar_Ordrar_OrderId",
                table: "Varukorgar",
                column: "OrderId",
                principalTable: "Ordrar",
                principalColumn: "Id");
        }
    }
}
