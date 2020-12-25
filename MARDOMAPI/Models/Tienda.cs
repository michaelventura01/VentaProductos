using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MARDOMAPI.Models
{
    public class Tienda
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public string Nombre{set; get;}
        [Required]
        public string Direccion{set; get;}
        [Required]
        public bool Estatus{set; get;}
        [Required]
        public Ciudad ciudad{set; get;}

        public List<ProductoTienda> ProductosTiendas{get; set;}
    }
}