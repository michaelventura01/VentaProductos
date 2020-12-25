using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MARDOMAPI
{
    [Keyless]
    public partial class VerUsuario
    {
        public string Codigo { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Estatus { get; set; }
        public string Tienda { get; set; }
        public string Tipo_Usuario { get; set; }
    }
}



