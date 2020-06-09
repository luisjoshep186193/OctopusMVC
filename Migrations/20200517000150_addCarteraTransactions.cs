using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class addCarteraTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarteraTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionDesc = table.Column<string>(nullable: false),
                    Monto = table.Column<double>(nullable: false),
                    FechaOperation = table.Column<DateTime>(nullable: false),
                    CarteraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteraTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarteraTransactions_Carteras_CarteraId",
                        column: x => x.CarteraId,
                        principalTable: "Carteras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarteraTransactions_CarteraId",
                table: "CarteraTransactions",
                column: "CarteraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteraTransactions");
        }
    }
}
