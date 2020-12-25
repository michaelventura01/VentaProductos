using System.ComponentModel.DataAnnotations;

namespace MARDOMAPI.Models
{
    public class ProductoFactura
    {
        [Key]
        public string Codigo{set; get;}

        public string ProductoCodigo{set; get;}
        public Producto Producto{set; get;}
        public string FacturaCodigo{set; get;}
        public Factura Factura{set; get;}
        [Required]
        public int Cantidad{set; get;}
    
        [Required]
        public double Precio{set; get;}

        [Required]
        public string Descuento{set; get;}
        
        [Required]
        public string Impuesto{set; get;}
    
        [Required]
        public bool Estatus{set; get;} 
    }
}