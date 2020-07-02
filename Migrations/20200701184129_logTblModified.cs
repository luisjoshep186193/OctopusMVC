using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class logTblModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Recargas_RecargaId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_RecargaId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "LogDesc",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "RecargaId",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Init",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Logs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Init",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "LogDesc",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecargaId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_RecargaId",
                table: "Logs",
                column: "RecargaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Recargas_RecargaId",
                table: "Logs",
                column: "RecargaId",
                principalTable: "Recargas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
