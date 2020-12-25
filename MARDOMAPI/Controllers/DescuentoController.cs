using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MARDOMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DescuentoController : Controller
    {
        private readonly AplicationDBContext context;
        public DescuentoController(AplicationDBContext context){
            this.context = context;

        }
        [HttpGet]
        public ActionResult<Verdescuento> Get(){
            try{
                var listadescuentos = context.Verdescuentos.ToList();
                if(listadescuentos== null){
                    return NotFound();
                }
                return Ok(listadescuentos);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public string Get(int id){
            return "hola";
        }

        [HttpPost]
        public void Post([FromBody] string value){

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value){}

        [HttpDelete("{id}")]
        public void Delete(int id){}
    }
}