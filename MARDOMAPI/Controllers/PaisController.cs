using System;
using System.Collections.Generic;
using System.Linq;
using MARDOMAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MARDOMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController: Controller
    {
        private readonly AplicationDBContext context;
        public PaisController(AplicationDBContext context){
            this.context = context;

        }
        [HttpGet]
        public ActionResult<List<VerPais>> Get(){
            try{
                var listaPaises = this.context.VerPaises.ToList();
                if(listaPaises== null){
                    return NotFound();
                }
                return Ok(listaPaises);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet("{codigo}")]
        public ActionResult<Pais> Get(string codigo){
            try{
                var pais = this.context.Paises.Find(codigo);
                if(pais== null){
                    return NotFound();
                }

                return Ok(pais); 
                
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Pais pais){
             
            try{
                context.Database.ExecuteSqlRaw("EXEC agregarPais {0}, {1}", pais.Codigo, pais.Nombre);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            }

        }

        [HttpPut("{codigo}")]
        public ActionResult Put(string codigo, [FromBody] Pais pais){
            try{
                context.Database.ExecuteSqlRaw("EXEC modificarPais {0}, {1}, {2}", pais.Codigo, pais.Nombre, codigo);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            }

        }
    }
}