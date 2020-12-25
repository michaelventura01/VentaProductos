using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace MARDOMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImpuestoController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get(){
            return new string[]{"hola", "adios"};
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