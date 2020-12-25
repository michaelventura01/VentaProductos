﻿// <auto-generated />
using System;
using MARDOMAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MARDOMAPI.Migrations
{
    [DbContext(typeof(AplicationDBContext))]
    [Migration("20201224141242_correctionviews")]
    partial class correctionviews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MARDOMAPI.CiudadesVer", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("CiudadesVers");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Ciudad", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Descuento", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<decimal>("Porcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductoCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("ProductoCodigo");

                    b.ToTable("DescuentosProductos");
                });

            modelBuilder.Entity("MARDOMAPI.Models.EstatusFactura", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("FacturaEstatus");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Factura", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Tiempo")
                        .HasColumnType("datetime2");

                    b.HasKey("Codigo");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Impuesto", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<decimal>("Porcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductoCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("ProductoCodigo");

                    b.ToTable("ImpuestosProductos");
                });

            modelBuilder.Entity("MARDOMAPI.Models.PagoFactura", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FacturaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Tiempo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Codigo");

                    b.HasIndex("FacturaCodigo");

                    b.ToTable("PagoFacturas");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Pais", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Producto", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("MARDOMAPI.Models.ProductoFactura", b =>
                {
                    b.Property<string>("FacturaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductoCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descuento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<string>("Impuesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("FacturaCodigo", "ProductoCodigo");

                    b.HasIndex("ProductoCodigo");

                    b.ToTable("ProductoFacturas");
                });

            modelBuilder.Entity("MARDOMAPI.Models.ProductoTienda", b =>
                {
                    b.Property<string>("TiendaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductoCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TiendaCodigo", "ProductoCodigo");

                    b.HasIndex("ProductoCodigo");

                    b.ToTable("ProductoTiendas");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Tienda", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ciudadCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("ciudadCodigo");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("MARDOMAPI.Models.TipoUsuario", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("TipoUsuarios");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Usuario", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CiudadCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuarioCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("CiudadCodigo");

                    b.HasIndex("TipoUsuarioCodigo");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MARDOMAPI.VerDetallesFactura", b =>
                {
                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CodigoEnFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Tiempo")
                        .HasColumnType("datetime2");

                    b.ToTable("VerDetallesFacturas");
                });

            modelBuilder.Entity("MARDOMAPI.VerPais", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("VerPaises");
                });

            modelBuilder.Entity("MARDOMAPI.VerProductosTienda", b =>
                {
                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoTienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionTienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tienda")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("VerProductosTiendas");
                });

            modelBuilder.Entity("MARDOMAPI.VerProductosTiendasActivo", b =>
                {
                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoTienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionTienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tienda")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("VerProductosTiendasActivos");
                });

            modelBuilder.Entity("MARDOMAPI.VerTienda", b =>
                {
                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoTitular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titular")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("VerTiendas");
                });

            modelBuilder.Entity("MARDOMAPI.VerUsuario", b =>
                {
                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("VerUsuarios");
                });

            modelBuilder.Entity("MARDOMAPI.Verdescuento", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoProductoTienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Porcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Producto")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Verdescuentos");
                });

            modelBuilder.Entity("MARDOMAPI.Verdescuentossactivo", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoProductoTienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Porcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Producto")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Verdescuentossactivos");
                });

            modelBuilder.Entity("MARDOMAPI.Verimpuesto", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoProductoTienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Porcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Producto")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Verimpuestos");
                });

            modelBuilder.Entity("MARDOMAPI.Verimpuestosactivo", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoProductoTienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Porcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Producto")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Verimpuestosactivos");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Descuento", b =>
                {
                    b.HasOne("MARDOMAPI.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoCodigo");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Impuesto", b =>
                {
                    b.HasOne("MARDOMAPI.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoCodigo");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("MARDOMAPI.Models.PagoFactura", b =>
                {
                    b.HasOne("MARDOMAPI.Models.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaCodigo");

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("MARDOMAPI.Models.ProductoFactura", b =>
                {
                    b.HasOne("MARDOMAPI.Models.Factura", "Factura")
                        .WithMany("ProductosFacturas")
                        .HasForeignKey("FacturaCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MARDOMAPI.Models.Producto", "Producto")
                        .WithMany("ProductosFacturas")
                        .HasForeignKey("ProductoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("MARDOMAPI.Models.ProductoTienda", b =>
                {
                    b.HasOne("MARDOMAPI.Models.Producto", "Producto")
                        .WithMany("ProductosTiendas")
                        .HasForeignKey("ProductoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MARDOMAPI.Models.Tienda", "Tienda")
                        .WithMany("ProductosTiendas")
                        .HasForeignKey("TiendaCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Tienda", b =>
                {
                    b.HasOne("MARDOMAPI.Models.Ciudad", "ciudad")
                        .WithMany()
                        .HasForeignKey("ciudadCodigo");

                    b.Navigation("ciudad");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Usuario", b =>
                {
                    b.HasOne("MARDOMAPI.Models.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadCodigo");

                    b.HasOne("MARDOMAPI.Models.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioCodigo");

                    b.Navigation("Ciudad");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Factura", b =>
                {
                    b.Navigation("ProductosFacturas");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Producto", b =>
                {
                    b.Navigation("ProductosFacturas");

                    b.Navigation("ProductosTiendas");
                });

            modelBuilder.Entity("MARDOMAPI.Models.Tienda", b =>
                {
                    b.Navigation("ProductosTiendas");
                });
#pragma warning restore 612, 618
        }
    }
}
