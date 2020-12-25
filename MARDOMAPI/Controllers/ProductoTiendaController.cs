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
    public class ProductoTiendaController: Controller
    {
        private readonly AplicationDBContext context;
        public ProductoTiendaController(AplicationDBContext context){
            this.context = context;

        }
        [HttpGet]
        public ActionResult<List<VerProductosTienda>> Get(){
            try{
                var listaproductos = this.context.VerProductosTiendas.ToList();
                if(listaproductos == null){
                    return NotFound();
                }
                return Ok(listaproductos);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpGet("{codigo}")]
        public ActionResult<VerProductosTienda> Get(string codigo){
            try{
                var producto = context.VerProductosTiendas.FromSqlRaw<VerProductosTienda>("exec tenerproducto {0}", codigo).ToList().FirstOrDefault();
                if(producto == null){
                    return NotFound();
                }
                return Ok(producto);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] VerProductosTienda productotienda){
            try{
                var generator = new RandomGenerator();
                productotienda.CodigoProducto = "P"+generator.RandomString(9);
                productotienda.Codigo = "PT"+generator.RandomString(8);
                this.context.Database.ExecuteSqlRaw("EXEC agregarProductoTienda {0}, {1}, {2}, {3}, {4}, {5}", productotienda.CodigoProducto, productotienda.Nombre, productotienda.Codigo, productotienda.CodigoTienda, productotienda.Cantidad, productotienda.Precio);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpPut("{codigo}")]
        public ActionResult Put(string codigo, [FromBody] VerProductosTienda productotienda){
            try{
                if(codigo == productotienda.Codigo){
                    this.context.Database.ExecuteSqlRaw("EXEC modificarProductoTienda {0}, {1}, {2}, {3}, {4}", 
                    productotienda.CodigoProducto, productotienda.Nombre, productotienda.Codigo, productotienda.Cantidad, productotienda.Precio);
                    return Ok();
                } else {
                    return NotFound();
                }
                
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }

        [HttpDelete("{codigo}")]
        public ActionResult Delete(string codigo, [FromBody] VerProductosTienda productotienda){
            try{
                if(productotienda.Estatus == "ACTIVO"){ 
                    this.context.Database.ExecuteSqlRaw("EXEC activarProductoTienda {0}", codigo);                    
                }
                if(productotienda.Estatus == "INACTIVO"){
                    this.context.Database.ExecuteSqlRaw("EXEC eliminarProductoTienda {0}", codigo);
                }
                
                return Ok();
                
                
            }catch(Exception ex){
                return BadRequest(ex);
            }

        }
    }
}