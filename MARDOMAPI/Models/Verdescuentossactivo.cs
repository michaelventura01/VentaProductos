using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MARDOMAPI
{
    [Keyless]
    public partial class Verdescuentossactivo
    {
        public string Producto { get; set; }
        public string CodigoProductoTienda { get; set; }
        public string Codigo { get; set; }
        public decimal Porcentage { get; set; }
        public string Estatus { get; set; }
    }
}
