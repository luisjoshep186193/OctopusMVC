using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class carrierResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResponseFromCarrier",
                table: "Recargas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseFromCarrier",
                table: "Recargas");
        }
    }
}
