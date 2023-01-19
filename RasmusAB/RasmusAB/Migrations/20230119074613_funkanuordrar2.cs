using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class funkanuordrar2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Användare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true),
                    VarukorgsId = table.Column<int>(type: "int", nullable: true),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Land = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefonnummer = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Användare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leverantörer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leverantörer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Varukorgar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnvändarId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varukorgar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Varukorgar_Användare_AnvändarId",
                        column: x => x.AnvändarId,
                        principalTable: "Användare",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produkter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    Färg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pris = table.Column<int>(type: "int", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkter_Kategorier_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategorier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ordrar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Summa = table.Column<int>(type: "int", nullable: true),
                    Moms = table.Column<double>(type: "float", nullable: true),
                    BetalningsUppgifter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slutbetald = table.Column<bool>(type: "bit", nullable: true),
                    VarukorgsId = table.Column<int>(type: "int", nullable: true),
                    LeverantörsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordrar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordrar_Leverantörer_LeverantörsId",
                        column: x => x.LeverantörsId,
                        principalTable: "Leverantörer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ordrar_Varukorgar_Id",
                        column: x => x.Id,
                        principalTable: "Varukorgar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Varukorgsprodukts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Varukorgsprodukts_Varukorgar_VarukorgId",
                        column: x => x.VarukorgId,
                        principalTable: "Varukorgar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_LeverantörsId",
                table: "Ordrar",
                column: "LeverantörsId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_KategoriId",
                table: "Produkter",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_AnvändarId",
                table: "Varukorgar",
                column: "AnvändarId",
                unique: true,
                filter: "[AnvändarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgsprodukts_ProduktId",
                table: "Varukorgsprodukts",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgsprodukts_VarukorgId",
                table: "Varukorgsprodukts",
                column: "VarukorgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordrar");

            migrationBuilder.DropTable(
                name: "Varukorgsprodukts");

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
