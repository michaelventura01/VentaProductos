using System.ComponentModel.DataAnnotations;

namespace MARDOMAPI.Models
{
    public class ProductoTienda
    {
        [Key]
        public string Codigo {set; get;}
        public string TiendaCodigo{set; get;}
        public Tienda Tienda{set; get;}
        public string ProductoCodigo{set; get;}
        public Producto Producto{set; get;}
        [Required]
        public bool Estatus {set; get;}
        [Required]
        public decimal Cantidad {set; get;}
        [Required]
        public decimal Precio {set; get;}
    }
}