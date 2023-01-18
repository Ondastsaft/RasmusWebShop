using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class ordersordersmeraorders2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "LeverantörId",
                table: "Ordrar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LeverantörsId",
                table: "Ordrar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar",
                column: "LeverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Leverantörer_LeverantörId",
                table: "Ordrar");

            migrationBuilder.DropColumn(
                name: "LeverantörsId",
                table: "Ordrar");

            migrationBuilder.RenameColumn(
                name: "LeverantörId",
                table: "Ordrar",
                newName: "leverantörId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordrar_LeverantörId",
                table: "Ordrar",
                newName: "IX_Ordrar_leverantörId");

            migrationBuilder.AlterColumn<int>(
                name: "leverantörId",
                table: "Ordrar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Leverantörer_leverantörId",
                table: "Ordrar",
                column: "leverantörId",
                principalTable: "Leverantörer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
