using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MARDOMAPI
{
    [Keyless]
    public partial class VerDetallesFactura
    {
        public string CodigoFactura { get; set; }
        public DateTime Tiempo { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string CodigoProducto { get; set; }
        public string CodigoEnFactura { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Impuesto { get; set; }
        public string Estatus { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
