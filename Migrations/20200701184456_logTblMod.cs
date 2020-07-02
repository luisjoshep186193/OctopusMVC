using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class logTblMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Description",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Logs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Init",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
