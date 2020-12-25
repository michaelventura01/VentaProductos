using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MARDOMAPI.Models;
namespace MARDOMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly AplicationDBContext context;
        public UsuarioController(AplicationDBContext context){
            this.context = context;

        }
        [HttpGet]
        [HttpGet]
        public ActionResult<List<VerUsuario>> Get(){
            try{
                var listaUsuarios = this.context.VerUsuarios.ToList();
                if(listaUsuarios == null){
                    return NotFound();
                }
                return Ok(listaUsuarios);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet("{codigo}")]
        public ActionResult<VerUsuario> Get(string codigo){
            try{
                var usuario = context.VerUsuarios.FromSqlRaw<VerUsuario>("exec tenerusuario {0}", codigo).ToList();
                if(usuario == null){
                    return NotFound();
                }
                return Ok(usuario);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<VerUsuario> Post([FromBody] VerUsuario usuario){
            try{
                var resultado = context.VerUsuarios.FromSqlRaw<VerUsuario>("exec ingresoUsuario {0}, {1}", usuario.Usuario, Seguridad.Encriptar(usuario.Clave)).ToList();
                if(resultado == null){
                    return NotFound();
                }
                return Ok(resultado);
            }catch(Exception ex){
                return BadRequest(ex);
            }

        }

        [HttpDelete]
        public ActionResult Delete([FromBody] VerUsuario usuario){
            try{
                int estatus = 0;
                if(usuario.Estatus == "ACTIVO"){ estatus = 1;}
                if (usuario.Estatus == "INACTIVO"){estatus = 0;}
                this.context.Database.ExecuteSqlRaw("EXEC activarusuario {0}, {1}", usuario.Usuario, estatus);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }
    }
}