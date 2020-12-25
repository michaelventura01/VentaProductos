using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MARDOMAPI
{
    [Keyless]
    public partial class CiudadesVer
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
    }
}
