using System;
using System.Collections.Generic;
using System.Linq;
using MARDOMAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace MARDOMAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : Controller
    {
        private readonly AplicationDBContext context;
        public ProductoController(AplicationDBContext context){
            this.context = context;

        }
        [HttpGet]
        public ActionResult<List<Producto>> Get(){
            try{
                var listaProductos = this.context.Productos.ToList();
                if(listaProductos== null){
                    return NotFound();
                }
                return Ok(listaProductos);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
        
    }
}