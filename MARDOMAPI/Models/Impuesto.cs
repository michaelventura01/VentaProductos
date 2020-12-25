using System.ComponentModel.DataAnnotations;
namespace MARDOMAPI.Models
{
    public class Impuesto
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public decimal Porcentage{set; get;}
        [Required]
        public bool Estatus{set; get;}
        public string ProductoCodigo{set; get;}
        public Producto Producto{set; get;}
    }
}