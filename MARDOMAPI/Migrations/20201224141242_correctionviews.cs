using Microsoft.EntityFrameworkCore.Migrations;

namespace MARDOMAPI.Migrations
{
    public partial class correctionviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Paises_PaisCodigo",
                table: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Ciudades_PaisCodigo",
                table: "Ciudades");

            migrationBuilder.DropColumn(
                name: "PaisCodigo",
                table: "Ciudades");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Ciudades",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Ciudades");

            migrationBuilder.AddColumn<string>(
                name: "PaisCodigo",
                table: "Ciudades",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PaisCodigo",
                table: "Ciudades",
                column: "PaisCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Paises_PaisCodigo",
                table: "Ciudades",
                column: "PaisCodigo",
                principalTable: "Paises",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
