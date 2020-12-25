using System;
using System.Collections.Generic;
using System.Linq;
using MARDOMAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace MARDOMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendaController : Controller
    {
        private readonly AplicationDBContext context;
        public TiendaController(AplicationDBContext context){
            this.context = context;

        }

        [HttpGet]
        public ActionResult<List<VerTienda>> Get(){
            try{
                var listaTiendas = this.context.VerTiendas.ToList();
                if(listaTiendas == null){
                    return NotFound();
                }
                return Ok(listaTiendas);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet("{codigo}")]
        public ActionResult<VerTienda> Get(string codigo){
            try{
                var ciudad = context.VerTiendas.FromSqlRaw<VerTienda>("exec tenertienda {0}", codigo).ToList();
                if(ciudad == null){
                    return NotFound();
                }
                return Ok(ciudad);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] VerTienda tienda){
            try{
                var generator = new RandomGenerator();
                tienda.Codigo = "T"+generator.RandomString(9);
                this.context.Database.ExecuteSqlRaw("EXEC agregarTienda {0}, {1}, {2}, {3}", tienda.Codigo, tienda.Nombre, tienda.Direccion, tienda.Ciudad);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }

        [HttpPut("{codigo}")]
        public ActionResult Put(string codigo, [FromBody] VerTienda tienda){
            try{
                this.context.Database.ExecuteSqlRaw("EXEC modificarTienda {0}, {1}, {2}, {3}", tienda.Codigo, tienda.Nombre, tienda.Direccion, tienda.Ciudad);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }

        [HttpDelete("{codigo}")]
        public ActionResult Delete(string codigo, [FromBody] VerTienda tienda){
            try{
                int estatus = 0;
                if(tienda.Estatus == "ACTIVO"){ estatus = 1;}
                if (tienda.Estatus == "INACTIVO"){estatus = 0;}
                this.context.Database.ExecuteSqlRaw("EXEC activartienda {0}, {1}", codigo, estatus);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }
    }
}