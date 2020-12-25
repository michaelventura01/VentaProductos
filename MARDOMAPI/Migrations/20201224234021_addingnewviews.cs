using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MARDOMAPI.Migrations
{
    public partial class addingnewviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoUsuario",
                table: "VerUsuarios",
                newName: "Tipo_Usuario");

            migrationBuilder.RenameColumn(
                name: "CorreoTitular",
                table: "VerTiendas",
                newName: "Correo_Titular");

            migrationBuilder.CreateTable(
                name: "VerFacturaTienda",
                columns: table => new
                {
                    Tiempo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreTienda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoTienda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerFacturaTienda");

            migrationBuilder.RenameColumn(
                name: "Tipo_Usuario",
                table: "VerUsuarios",
                newName: "TipoUsuario");

            migrationBuilder.RenameColumn(
                name: "Correo_Titular",
                table: "VerTiendas",
                newName: "CorreoTitular");
        }
    }
}
