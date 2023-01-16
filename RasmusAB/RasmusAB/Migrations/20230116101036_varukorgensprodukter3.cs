using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class varukorgensprodukter3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnvädareVarukorgId",
                table: "Varukorgar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnvädareVarukorgId",
                table: "Varukorgar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
