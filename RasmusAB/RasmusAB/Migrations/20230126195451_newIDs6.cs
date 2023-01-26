using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class newIDs6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Användare",
                columns: table => new
                {
                    AnvändareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Användare", x => x.AnvändareId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorier",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorier", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Leverantörer",
                columns: table => new
                {
                    LeverantörId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leverantörer", x => x.LeverantörId);
                });

            migrationBuilder.CreateTable(
                name: "Varukorgar",
                columns: table => new
                {
                    VarukorgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnvändareId = table.Column<int>(type: "int", nullable: false),
                    Slutbetald = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varukorgar", x => x.VarukorgId);
                    table.ForeignKey(
                        name: "FK_Varukorgar_Användare_AnvändareId",
                        column: x => x.AnvändareId,
                        principalTable: "Användare",
                        principalColumn: "AnvändareId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produkter",
                columns: table => new
                {
                    ProduktId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Färg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pris = table.Column<int>(type: "int", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkter", x => x.ProduktId);
                    table.ForeignKey(
                        name: "FK_Produkter_Kategorier_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorier",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordrar",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summa = table.Column<int>(type: "int", nullable: false),
                    Moms = table.Column<double>(type: "float", nullable: false),
                    BetalningsUppgifter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slutbetald = table.Column<bool>(type: "bit", nullable: false),
                    VarukorgId = table.Column<int>(type: "int", nullable: false),
                    LeverantörId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordrar", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Ordrar_Leverantörer_LeverantörId",
                        column: x => x.LeverantörId,
                        principalTable: "Leverantörer",
                        principalColumn: "LeverantörId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordrar_Varukorgar_VarukorgId",
                        column: x => x.VarukorgId,
                        principalTable: "Varukorgar",
                        principalColumn: "VarukorgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Varukorgsprodukter",
                columns: table => new
                {
                    VarukorgsproduktId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    VarukorgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varukorgsprodukter", x => x.VarukorgsproduktId);
                    table.ForeignKey(
                        name: "FK_Varukorgsprodukter_Produkter_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkter",
                        principalColumn: "ProduktId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Varukorgsprodukter_Varukorgar_VarukorgId",
                        column: x => x.VarukorgId,
                        principalTable: "Varukorgar",
                        principalColumn: "VarukorgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_LeverantörId",
                table: "Ordrar",
                column: "LeverantörId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_VarukorgId",
                table: "Ordrar",
                column: "VarukorgId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_KategoriId",
                table: "Produkter",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_AnvändareId",
                table: "Varukorgar",
                column: "AnvändareId");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgsprodukter_ProduktId",
                table: "Varukorgsprodukter",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgsprodukter_VarukorgId",
                table: "Varukorgsprodukter",
                column: "VarukorgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordrar");

            migrationBuilder.DropTable(
                name: "Varukorgsprodukter");

            migrationBuilder.DropTable(
                name: "Leverantörer");

            migrationBuilder.DropTable(
                name: "Produkter");

            migrationBuilder.DropTable(
                name: "Varukorgar");

            migrationBuilder.DropTable(
                name: "Kategorier");

            migrationBuilder.DropTable(
                name: "Användare");
        }
    }
}
