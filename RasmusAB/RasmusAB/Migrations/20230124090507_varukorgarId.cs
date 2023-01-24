using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class varukorgarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Användare_VarukorgId",
                table: "Användare");

            migrationBuilder.AlterColumn<int>(
                name: "AnvändarId",
                table: "Varukorgar",
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
                unique: true,
                filter: "[VarukorgId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Användare_VarukorgId",
                table: "Användare");

            migrationBuilder.AlterColumn<int>(
                name: "AnvändarId",
                table: "Varukorgar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Användare_VarukorgId",
                table: "Användare",
                column: "VarukorgId");
        }
    }
}
