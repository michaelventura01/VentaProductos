using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MARDOMAPI
{
    [Keyless]
    public partial class VerTienda
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Estatus { get; set; }
        public string Titular { get; set; }
        public string Correo_Titular { get; set; }
    }
}
