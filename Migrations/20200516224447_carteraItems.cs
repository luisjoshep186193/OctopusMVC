using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class carteraItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Asignado",
                table: "Carteras",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Inicial",
                table: "Carteras",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Venta",
                table: "Carteras",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asignado",
                table: "Carteras");

            migrationBuilder.DropColumn(
                name: "Inicial",
                table: "Carteras");

            migrationBuilder.DropColumn(
                name: "Venta",
                table: "Carteras");
        }
    }
}
