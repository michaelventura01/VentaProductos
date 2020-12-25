using System.ComponentModel.DataAnnotations;

namespace MARDOMAPI.Models
{
    public class EstatusFactura
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public string Descripcion{set; get;}
    }
}