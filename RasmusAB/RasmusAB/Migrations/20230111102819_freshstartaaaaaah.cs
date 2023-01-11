using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class freshstartaaaaaah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Produktlistor_ProduktlistaId",
                table: "Produkter");

            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Produktlistor_ProduktListaId",
                table: "Varukorgar");

            migrationBuilder.DropTable(
                name: "Användarregister");

            migrationBuilder.DropTable(
                name: "Produktlistor");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_ProduktListaId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "ProduktListaId",
                table: "Varukorgar");

            migrationBuilder.RenameColumn(
                name: "ProduktlistaId",
                table: "Produkter",
                newName: "VarukorgId");

            migrationBuilder.RenameIndex(
                name: "IX_Produkter_ProduktlistaId",
                table: "Produkter",
                newName: "IX_Produkter_VarukorgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Varukorgar_VarukorgId",
                table: "Produkter",
                column: "VarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Varukorgar_VarukorgId",
                table: "Produkter");

            migrationBuilder.RenameColumn(
                name: "VarukorgId",
                table: "Produkter",
                newName: "ProduktlistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Produkter_VarukorgId",
                table: "Produkter",
                newName: "IX_Produkter_ProduktlistaId");

            migrationBuilder.AddColumn<int>(
                name: "ProduktListaId",
                table: "Varukorgar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Användarregister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    KundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Användarregister", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_ProduktListaId",
                table: "Varukorgar",
                column: "ProduktListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Produktlistor_ProduktlistaId",
                table: "Produkter",
                column: "ProduktlistaId",
                principalTable: "Produktlistor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgar_Produktlistor_ProduktListaId",
                table: "Varukorgar",
                column: "ProduktListaId",
                principalTable: "Produktlistor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
