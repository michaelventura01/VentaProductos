using System.ComponentModel.DataAnnotations;
namespace MARDOMAPI.Models
{
    public class Usuario
    {
        [Key]
        public string Codigo{set; get;}
        [Required]
        public string User{set; get;}
        [Required]
        public string Nombre{set; get;}
        [Required]
        public string Apellido{set; get;}
        [Required]
        public string Correo{set; get;}
        [Required]
        public string Clave{set; get;}
        [Required]
        public bool Estatus{set; get;}
        public string CiudadCodigo{set; get;}
        public Ciudad Ciudad{set; get;}
        public string TipoUsuarioCodigo{set; get;}
        public TipoUsuario TipoUsuario{set; get;}

    }
}