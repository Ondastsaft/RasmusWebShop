using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class varukorgsprodukter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktVarukorg");

            migrationBuilder.AddColumn<int>(
                name: "ProduktId",
                table: "Varukorgar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Varukorgsprodukts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    VarukorgId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varukorgsprodukts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Varukorgsprodukts_Produkter_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Varukorgsprodukts_Varukorgar_VarukorgId",
                        column: x => x.VarukorgId,
                        principalTable: "Varukorgar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_ProduktId",
                table: "Varukorgar",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgsprodukts_ProduktId",
                table: "Varukorgsprodukts",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgsprodukts_VarukorgId",
                table: "Varukorgsprodukts",
                column: "VarukorgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgar_Produkter_ProduktId",
                table: "Varukorgar",
                column: "ProduktId",
                principalTable: "Produkter",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Produkter_ProduktId",
                table: "Varukorgar");

            migrationBuilder.DropTable(
                name: "Varukorgsprodukts");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_ProduktId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "ProduktId",
                table: "Varukorgar");

            migrationBuilder.CreateTable(
                name: "ProduktVarukorg",
                columns: table => new
                {
                    ProduktersId = table.Column<int>(type: "int", nullable: false),
                    VarukorgsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktVarukorg", x => new { x.ProduktersId, x.VarukorgsId });
                    table.ForeignKey(
                        name: "FK_ProduktVarukorg_Produkter_ProduktersId",
                        column: x => x.ProduktersId,
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
    }
}
