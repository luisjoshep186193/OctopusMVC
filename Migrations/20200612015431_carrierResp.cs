using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class carrierResp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrierResponse",
                table: "CarteraTransactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierResponse",
                table: "CarteraTransactions");
        }
    }
}
