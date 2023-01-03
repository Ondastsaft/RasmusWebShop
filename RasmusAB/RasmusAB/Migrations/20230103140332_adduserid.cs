﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RasmusAB.Migrations
{
    public partial class adduserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Användarregister",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KundId",
                table: "Användarregister",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Användarregister");

            migrationBuilder.DropColumn(
                name: "KundId",
                table: "Användarregister");
        }
    }
}
