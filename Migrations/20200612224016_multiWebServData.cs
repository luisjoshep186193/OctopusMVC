using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class multiWebServData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrierTempName",
                table: "Recargas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Intent",
                table: "Recargas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RecargaReq",
                table: "Recargas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierTempName",
                table: "Recargas");

            migrationBuilder.DropColumn(
                name: "Intent",
                table: "Recargas");

            migrationBuilder.DropColumn(
                name: "RecargaReq",
                table: "Recargas");
        }
    }
}
