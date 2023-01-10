using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class LäggTillKund : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KundId",
                table: "Varukorgar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Varukorgar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProduktListaId",
                table: "Varukorgar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProduktlistaId",
                table: "Produkter",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinVarukorgId",
                table: "Användare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VarukorgsId",
                table: "Användare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "varukorgsId",
                table: "Användare",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_ProduktListaId",
                table: "Varukorgar",
                column: "ProduktListaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_KategoriId",
                table: "Produkter",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkter_ProduktlistaId",
                table: "Produkter",
                column: "ProduktlistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Användare_MinVarukorgId",
                table: "Användare",
                column: "MinVarukorgId");

            migrationBuilder.AddForeignKey(
                name: "FK_Användare_Varukorgar_MinVarukorgId",
                table: "Användare",
                column: "MinVarukorgId",
                principalTable: "Varukorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter",
                column: "KategoriId",
                principalTable: "Kategorier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Användare_Varukorgar_MinVarukorgId",
                table: "Användare");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Produktlistor_ProduktlistaId",
                table: "Produkter");

            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Produktlistor_ProduktListaId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_ProduktListaId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Produkter_KategoriId",
                table: "Produkter");

            migrationBuilder.DropIndex(
                name: "IX_Produkter_ProduktlistaId",
                table: "Produkter");

            migrationBuilder.DropIndex(
                name: "IX_Användare_MinVarukorgId",
                table: "Användare");

            migrationBuilder.DropColumn(
                name: "KundId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "ProduktListaId",
                table: "Varukorgar");

            migrationBuilder.DropColumn(
                name: "ProduktlistaId",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "MinVarukorgId",
                table: "Användare");

            migrationBuilder.DropColumn(
                name: "VarukorgsId",
                table: "Användare");

            migrationBuilder.DropColumn(
                name: "varukorgsId",
                table: "Användare");
        }
    }
}
