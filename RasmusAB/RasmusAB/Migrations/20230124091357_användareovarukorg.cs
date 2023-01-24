using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class användareovarukorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Användare_Varukorgar_VarukorgId",
                table: "Användare");

            migrationBuilder.DropIndex(
                name: "IX_Användare_VarukorgId",
                table: "Användare");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgId",
                table: "Användare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Användare_Varukorgar_VarukorgId",
                table: "Användare");

            migrationBuilder.DropIndex(
                name: "IX_Användare_VarukorgId",
                table: "Användare");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgId",
                table: "Användare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Användare_VarukorgId",
                table: "Användare",
                column: "VarukorgId",
                unique: true,
                filter: "[VarukorgId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Användare_Varukorgar_VarukorgId",
                table: "Användare",
                column: "VarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id");
        }
    }
}
