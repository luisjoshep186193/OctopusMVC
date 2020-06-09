using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class CarteraIdLvl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Carteras",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLevel",
                table: "Carteras",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Carteras");

            migrationBuilder.DropColumn(
                name: "UserLevel",
                table: "Carteras");
        }
    }
}
