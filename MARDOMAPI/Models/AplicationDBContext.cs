using System;
using MARDOMAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace MARDOMAPI
{
    public class AplicationDBContext: DbContext
    {
         public AplicationDBContext(){}
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options):base(options){}
        public DbSet<Pais> Paises{get; set;}
        public DbSet<Ciudad> Ciudades{set; get;}
        public DbSet<Tienda> Tiendas{set; get;}
        public DbSet<Producto> Productos{set; get;}
        public DbSet<ProductoTienda> ProductoTiendas{set; get;}
        public DbSet<Usuario> Usuarios{set; get;}
        public DbSet<TipoUsuario> TipoUsuarios{set; get;}
        public DbSet<EstatusFactura> FacturaEstatus{set; get;}
        public DbSet<Factura> Facturas{set; get;}
        public DbSet<PagoFactura> PagoFacturas{set; get;}
        public DbSet<ProductoFactura> ProductoFacturas{set; get;}
        public DbSet<Impuesto> ImpuestosProductos{set; get;}
        public DbSet<Descuento> DescuentosProductos{set; get;}
        public virtual DbSet<CiudadesVer> CiudadesVers { get; set; }
        public virtual DbSet<VerDetallesFactura> VerDetallesFacturas { get; set; }
        public virtual DbSet<VerPais> VerPaises { get; set; }
        public virtual DbSet<VerProductosTienda> VerProductosTiendas { get; set; }
        public virtual DbSet<VerProductosTiendasActivo> VerProductosTiendasActivos { get; set; }
        public virtual DbSet<VerTienda> VerTiendas { get; set; }
        public virtual DbSet<VerUsuario> VerUsuarios { get; set; }
        public virtual DbSet<Verdescuento> Verdescuentos { get; set; }
        public virtual DbSet<Verdescuentossactivo> Verdescuentossactivos { get; set; }
        public virtual DbSet<Verimpuesto> Verimpuestos { get; set; }
        public virtual DbSet<Verimpuestosactivo> Verimpuestosactivos { get; set; }
        public virtual DbSet<VerFacturaTienda> VerFacturaTiendas { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Server=tcp:mardomproducts.database.windows.net,1433;Initial Catalog=DBProductsMARDOM;Persist Security Info=False;User ID=developer;Password=a@123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ProductoFactura>(entity => {
                entity.HasKey(e => new {e.FacturaCodigo, e.ProductoCodigo});
            });
            modelBuilder.Entity<ProductoTienda>(entity => {
                entity.HasKey(e => new {e.TiendaCodigo, e.ProductoCodigo});
            });
            // base.OnModelCreating(modelBuilder);
        }
    }
}