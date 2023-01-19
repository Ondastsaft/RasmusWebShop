using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class funkanuordrar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Varukorgar_VarukorgsId",
                table: "Ordrar");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter");

            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Användare_AnvändarId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_AnvändarId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Ordrar_VarukorgsId",
                table: "Ordrar");

            migrationBuilder.AlterColumn<int>(
                name: "AnvändarId",
                table: "Varukorgar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Namn",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Produkter",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Färg",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Antal",
                table: "Produkter",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgsId",
                table: "Ordrar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ordrar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Leverantörer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leverantörer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Namn",
                table: "Kategorier",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgsId",
                table: "Användare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Användare",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_AnvändarId",
                table: "Varukorgar",
                column: "AnvändarId",
                unique: true,
                filter: "[AnvändarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Varukorgar_Id",
                table: "Ordrar",
                column: "Id",
                principalTable: "Varukorgar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter",
                column: "KategoriId",
                principalTable: "Kategorier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Varukorgar_Användare_AnvändarId",
                table: "Varukorgar",
                column: "AnvändarId",
                principalTable: "Användare",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrar_Varukorgar_Id",
                table: "Ordrar");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkter_Kategorier_KategoriId",
                table: "Produkter");

            migrationBuilder.DropForeignKey(
                name: "FK_Varukorgar_Användare_AnvändarId",
                table: "Varukorgar");

            migrationBuilder.DropIndex(
                name: "IX_Varukorgar_AnvändarId",
                table: "Varukorgar");

            migrationBuilder.AlterColumn<int>(
                name: "AnvändarId",
                table: "Varukorgar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Namn",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Produkter",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Färg",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Antal",
                table: "Produkter",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgsId",
                table: "Ordrar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ordrar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Leverantörer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leverantörer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Namn",
                table: "Kategorier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VarukorgsId",
                table: "Användare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "Användare",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Varukorgar_AnvändarId",
                table: "Varukorgar",
                column: "AnvändarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordrar_VarukorgsId",
                table: "Ordrar",
                column: "VarukorgsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrar_Varukorgar_VarukorgsId",
                table: "Ordrar",
                column: "VarukorgsId",
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
                name: "FK_Varukorgar_Användare_AnvändarId",
                table: "Varukorgar",
                column: "AnvändarId",
                principalTable: "Användare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
