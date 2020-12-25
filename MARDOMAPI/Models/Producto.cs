using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MARDOMAPI.Models
{
    public class Producto
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public string Nombre{set; get;}

        public List<ProductoFactura> ProductosFacturas{get; set;}
        public List<ProductoTienda> ProductosTiendas{get; set;}

    }
}