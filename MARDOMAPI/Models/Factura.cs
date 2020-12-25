using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MARDOMAPI.Models
{
    public class Factura
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public DateTime Tiempo{set; get;}
        [Required]
        public string Estatus{set; get;}

        public string Tienda{set; get;}
        public List<ProductoFactura> ProductosFacturas{get; set;}
    }
}