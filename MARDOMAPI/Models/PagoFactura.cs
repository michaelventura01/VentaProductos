using System;
using System.ComponentModel.DataAnnotations;

namespace MARDOMAPI.Models
{
    public class PagoFactura
    {
        [Key]
        public string Codigo {set; get;}
        [Required]
        public DateTime Tiempo{set; get;}
        [Required]
        public decimal Total{set; get;}
        public string FacturaCodigo{set; get;}
        public Factura Factura{set; get;}
    }
}