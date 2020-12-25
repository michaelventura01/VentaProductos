using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MARDOMAPI
{
    [Keyless]
    public partial class VerPais
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
