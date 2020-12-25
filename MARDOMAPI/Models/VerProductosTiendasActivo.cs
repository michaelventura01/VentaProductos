using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MARDOMAPI
{
    [Keyless]
    public partial class VerProductosTiendasActivo
    {
        public string CodigoTienda { get; set; }
        public string Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Tienda { get; set; }
        public string DireccionTienda { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Nombre { get; set; }
        public string Estatus { get; set; }
    }
}
