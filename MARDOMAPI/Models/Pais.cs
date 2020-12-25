using System.ComponentModel.DataAnnotations;
namespace MARDOMAPI.Models
{
    public class Pais
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public string Nombre{set; get;}
    }
}