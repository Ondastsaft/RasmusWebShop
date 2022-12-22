using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ánvändare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usertype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ánvändare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordrar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordrar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produkter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produktlistor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produktlistor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Varukorgar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varukorgar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ánvändare");

            migrationBuilder.DropTable(
                name: "Kategorier");

            migrationBuilder.DropTable(
                name: "Ordrar");

            migrationBuilder.DropTable(
                name: "Produkter");

            migrationBuilder.DropTable(
                name: "Produktlistor");

            migrationBuilder.DropTable(
                name: "Varukorgar");
        }
    }
}
