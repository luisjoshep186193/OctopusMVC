using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class carriertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrierType",
                table: "Carriers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierType",
                table: "Carriers");
        }
    }
}
