using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MARDOMAPI.Models
{
    public class Ciudad
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public string Nombre{set; get;}
 
        public string Pais{set; get;}



    }
}