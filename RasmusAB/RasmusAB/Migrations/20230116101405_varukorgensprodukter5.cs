using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class varukorgensprodukter5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Varukorgar_VarukorgId",
                table: "Produkter");

            migrationBuilder.DropIndex(
                name: "IX_Produkter_VarukorgId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "VarukorgId",
                table: "Produkter");

            migrationBuilder.CreateTable(
                name: "ProduktVarukorg",
                columns: table => new
                {
                    VarukorgensProdukterId = table.Column<int>(type: "int", nullable: false),
                    VarukorgsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktVarukorg", x => new { x.VarukorgensProdukterId, x.VarukorgsId });
                    table.ForeignKey(
                        name: "FK_ProduktVarukorg_Produkter_VarukorgensProdukterId",
                        column: x => x.VarukorgensProdukterId,
                        principalTable: "Produkter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktVarukorg_Varukorgar_VarukorgsId",
                        column: x => x.VarukorgsId,
                        principalTable: "Varukorgar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduktVarukorg_VarukorgsId",
                table: "ProduktVarukorg",
                column: "VarukorgsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktVarukorg");

            migrationBuilder.AddColumn<int>(
                name: "VarukorgId",
                table: "Produkter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_VarukorgId",
                table: "Produkter",
                column: "VarukorgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Varukorgar_VarukorgId",
                table: "Produkter",
                column: "VarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id");
        }
    }
}
