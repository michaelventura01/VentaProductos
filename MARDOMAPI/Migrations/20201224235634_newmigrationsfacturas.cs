using Microsoft.EntityFrameworkCore.Migrations;

namespace MARDOMAPI.Migrations
{
    public partial class newmigrationsfacturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "VerFacturaTienda",
                newName: "VerFacturaTiendas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "VerFacturaTiendas",
                newName: "VerFacturaTienda");
        }
    }
}
