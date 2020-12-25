using System.ComponentModel.DataAnnotations;
namespace MARDOMAPI.Models
{
    public class TipoUsuario
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public string Descripcion{set; get;}
    }
}