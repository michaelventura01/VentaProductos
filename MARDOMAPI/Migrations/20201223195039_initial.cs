using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MARDOMAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacturaEstatus",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaEstatus", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tiempo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "PagoFacturas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tiempo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FacturaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoFacturas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_PagoFacturas_Facturas_FacturaCodigo",
                        column: x => x.FacturaCodigo,
                        principalTable: "Facturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Ciudades_Paises_PaisCodigo",
                        column: x => x.PaisCodigo,
                        principalTable: "Paises",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescuentosProductos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Porcentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    ProductoCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescuentosProductos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_DescuentosProductos_Productos_ProductoCodigo",
                        column: x => x.ProductoCodigo,
                        principalTable: "Productos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImpuestosProductos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Porcentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    ProductoCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpuestosProductos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_ImpuestosProductos_Productos_ProductoCodigo",
                        column: x => x.ProductoCodigo,
                        principalTable: "Productos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoFacturas",
                columns: table => new
                {
                    ProductoCodigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FacturaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Descuento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Impuesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoFacturas", x => new { x.FacturaCodigo, x.ProductoCodigo });
                    table.ForeignKey(
                        name: "FK_ProductoFacturas_Facturas_FacturaCodigo",
                        column: x => x.FacturaCodigo,
                        principalTable: "Facturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoFacturas_Productos_ProductoCodigo",
                        column: x => x.ProductoCodigo,
                        principalTable: "Productos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tiendas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    ciudadCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiendas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Tiendas_Ciudades_ciudadCodigo",
                        column: x => x.ciudadCodigo,
                        principalTable: "Ciudades",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    CiudadCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TipoUsuarioCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Usuarios_Ciudades_CiudadCodigo",
                        column: x => x.CiudadCodigo,
                        principalTable: "Ciudades",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_TipoUsuarioCodigo",
                        column: x => x.TipoUsuarioCodigo,
                        principalTable: "TipoUsuarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoTiendas",
                columns: table => new
                {
                    TiendaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductoCodigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoTiendas", x => new { x.TiendaCodigo, x.ProductoCodigo });
                    table.ForeignKey(
                        name: "FK_ProductoTiendas_Productos_ProductoCodigo",
                        column: x => x.ProductoCodigo,
                        principalTable: "Productos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoTiendas_Tiendas_TiendaCodigo",
                        column: x => x.TiendaCodigo,
                        principalTable: "Tiendas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PaisCodigo",
                table: "Ciudades",
                column: "PaisCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_DescuentosProductos_ProductoCodigo",
                table: "DescuentosProductos",
                column: "ProductoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ImpuestosProductos_ProductoCodigo",
                table: "ImpuestosProductos",
                column: "ProductoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_PagoFacturas_FacturaCodigo",
                table: "PagoFacturas",
                column: "FacturaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFacturas_ProductoCodigo",
                table: "ProductoFacturas",
                column: "ProductoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTiendas_ProductoCodigo",
                table: "ProductoTiendas",
                column: "ProductoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Tiendas_ciudadCodigo",
                table: "Tiendas",
                column: "ciudadCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CiudadCodigo",
                table: "Usuarios",
                column: "CiudadCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioCodigo",
                table: "Usuarios",
                column: "TipoUsuarioCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescuentosProductos");

            migrationBuilder.DropTable(
                name: "FacturaEstatus");

            migrationBuilder.DropTable(
                name: "ImpuestosProductos");

            migrationBuilder.DropTable(
                name: "PagoFacturas");

            migrationBuilder.DropTable(
                name: "ProductoFacturas");

            migrationBuilder.DropTable(
                name: "ProductoTiendas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Tiendas");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
