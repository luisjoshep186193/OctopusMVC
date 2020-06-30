using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class dateResetCartera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateReset",
                table: "Carteras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReset",
                table: "Carteras");
        }
    }
}
