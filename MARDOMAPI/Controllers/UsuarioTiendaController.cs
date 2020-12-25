using System;
using System.Collections.Generic;
using System.Linq;
using MARDOMAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MARDOMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioTiendaController: Controller
    {
        private readonly AplicationDBContext context;
        public UsuarioTiendaController(AplicationDBContext context){
            this.context = context;

        }

        [HttpGet]
        public ActionResult<List<VerUsuario>> Get(){
            try{
                var listaUsuariosTiendas = this.context.VerUsuarios.ToList();
                if(listaUsuariosTiendas == null){
                    return NotFound();
                }
                return Ok(listaUsuariosTiendas);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet("{codigo}")]
        public ActionResult<VerUsuario> Get(string codigo){
            try{
                var ciudad = context.VerUsuarios.FromSqlRaw<VerUsuario>("exec tenerusuario {0}", codigo).ToList();
                if(ciudad == null){
                    return NotFound();
                }
                return Ok(ciudad);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioTienda usuariotienda){
            try{
                var generator = new RandomGenerator();
                usuariotienda.CodigoUsuario = "U"+generator.RandomString(9);
                usuariotienda.CodigoTienda = "T"+generator.RandomString(9);
                string consulta = "EXEC agregarTiendaUsuario '"+
                    usuariotienda.CodigoUsuario+"','"+ //ramdom
                    usuariotienda.Usuario+"','"+  
                    Seguridad.Encriptar(usuariotienda.Clave)+"','"+  
                    usuariotienda.TipoUsuario+"','"+ 
                    usuariotienda.Nombre+"','"+ 
                    usuariotienda.Apellido+"','"+ 
                    usuariotienda.Correo+"','"+  
                    usuariotienda.Ciudad+"','"+  
                    usuariotienda.CodigoTienda+"','"+ //ramdon 
                    usuariotienda.NombreTienda+"','"+  
                    usuariotienda.Direccion+"'";
                this.context.Database.ExecuteSqlRaw(consulta);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }

        [HttpPut]
        public ActionResult Put([FromBody] UsuarioTienda usuariotienda){
            try{
                string consulta = "EXEC modificarTiendaUsuario '"+
                    usuariotienda.CodigoUsuario+"','"+ 
                    usuariotienda.Usuario+"','"+  
                    Seguridad.Encriptar(usuariotienda.Clave)+"','"+  
                    usuariotienda.TipoUsuario+"','"+ 
                    usuariotienda.Nombre+"','"+ 
                    usuariotienda.Apellido+"','"+ 
                    usuariotienda.Correo+"','"+  
                    usuariotienda.Ciudad+"','"+  
                    usuariotienda.CodigoTienda+"','"+  
                    usuariotienda.NombreTienda+"','"+  
                    usuariotienda.Direccion+"'";
                this.context.Database.ExecuteSqlRaw(consulta);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] VerUsuario usuariotienda){
            try{
                int estatus = 0;
                if(usuariotienda.Estatus == "ACTIVO"){ estatus = 1;}
                if (usuariotienda.Estatus == "INACTIVO"){estatus = 0;}
                this.context.Database.ExecuteSqlRaw("EXEC activartienda {0}, {1}", usuariotienda.Tienda, estatus);
                this.context.Database.ExecuteSqlRaw("EXEC activarusuario {0}, {1}", usuariotienda.Usuario, estatus);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }
    }
}
