using System;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace MARDOMAPI.Models
{
    [Keyless]
    public partial class VerFacturaTienda
    {
        public DateTime Tiempo{set; get;}
        public string CodigoFactura{set; get;}
        public string Estatus{set; get;}
        public string NombreTienda{set; get;}
        public string CodigoTienda{set; get;}
        public decimal Total{set; get;}

    }
}