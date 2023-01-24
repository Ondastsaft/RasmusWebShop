using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class Varukorgslista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Användare_Varukorgar_VarukorgId",
                table: "Användare");

            migrationBuilder.DropIndex(
                name: "IX_Användare_VarukorgId",
                table: "Användare");

            migrationBuilder.AddColumn<int>(
                name: "AnvändareId",
                table: "Varukorgar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Slutbetald",
                table: "Varukorgar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_AnvändareId",
                table: "Varukorgar",
                column: "AnvändareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgar_Användare_AnvändareId",
                table: "Varukorgar",
                column: "AnvändareId",
                principalTable: "Användare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Användare_AnvändareId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_AnvändareId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "AnvändareId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "Slutbetald",
                table: "Varukorgar");

            migrationBuilder.CreateIndex(
                name: "IX_Användare_VarukorgId",
                table: "Användare",
                column: "VarukorgId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Användare_Varukorgar_VarukorgId",
                table: "Användare",
                column: "VarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
