using System;
using System.Collections.Generic;
using System.Linq;
using MARDOMAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MARDOMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadController: Controller
    { 
        private readonly AplicationDBContext context;
        public CiudadController(AplicationDBContext context){
            this.context = context;

        }
        [HttpGet]
        public ActionResult<List<CiudadesVer>> Get(){   

            try{
                var listaCiudades = context.Ciudades.FromSqlRaw<Ciudad>("select * from ciudadesver").ToList();
                if(listaCiudades== null){
                    return NotFound();
                }
                return Ok(listaCiudades);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet("{codigo}")]
        public ActionResult<List<Ciudad>> Get(string codigo){
            try{
                Console.WriteLine("exec verCiudades {0}", codigo);
                var ciudades = this.context.Ciudades.FromSqlRaw<Ciudad>("exec verCiudades {0}", codigo).ToList();
                if(ciudades== null){
                    return NotFound();
                }
                return Ok(ciudades); 
                
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ciudad ciudad){
            try{
                this.context.Database.ExecuteSqlRaw("EXEC agregarCiudad {0}, {1}, {2}", ciudad.Codigo, ciudad.Nombre, ciudad.Pais);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            }

        }

        [HttpPut("{codigo}")]
        public ActionResult Put(string codigo, [FromBody] Ciudad ciudad){
            try{
                this.context.Database.ExecuteSqlRaw("EXEC modificarCiudad {0}, {1}, {2}, {3}", ciudad.Codigo, ciudad.Nombre, ciudad.Pais, codigo);
                return Ok();
                
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
    }
}