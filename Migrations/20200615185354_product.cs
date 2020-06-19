using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopus.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Hastags",
                table: "Productos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTypeId",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_GrupoId",
                table: "Productos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PTypeId",
                table: "Productos",
                column: "PTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Grupos_GrupoId",
                table: "Productos",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_PTypes_PTypeId",
                table: "Productos",
                column: "PTypeId",
                principalTable: "PTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Grupos_GrupoId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_PTypes_PTypeId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_GrupoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_PTypeId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Hastags",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PTypeId",
                table: "Productos");
        }
    }
}
