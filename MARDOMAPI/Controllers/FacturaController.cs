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
    public class FacturaController : Controller
    {
        private readonly AplicationDBContext context;
        public FacturaController(AplicationDBContext context){
            this.context = context;

        }

        [HttpGet("{codigo}")]
        public ActionResult<List<VerFacturaTienda>> Get(string codigo){
            try{
                var facturaLista = context.VerFacturaTiendas.FromSqlRaw<VerFacturaTienda>("EXEC tenerfacturastienda {0}", codigo).ToList();
                if(facturaLista == null){
                    return NotFound();
                }
                return Ok(facturaLista);
            }catch(Exception ex){
                return BadRequest(ex);
            }       
        }

        [HttpGet("factura/{codigo}")]
        public ActionResult<List<VerFacturaTienda>> Get(string factura, string codigo){
            try{
                var facturaLista = context.VerDetallesFacturas.FromSqlRaw<VerDetallesFactura>("EXEC tenerFactura {0}", codigo).ToList();
                if(facturaLista == null){
                    return NotFound();
                }
                return Ok(facturaLista);
            }catch(Exception ex){
                return BadRequest(ex);
            }       
        }

        [HttpPost]
        public ActionResult Post([FromBody] Factura factura){
            try{
                var generator = new RandomGenerator();
                factura.Codigo = "F"+generator.RandomString(9);
                context.Database.ExecuteSqlRaw("EXEC agregarFactura {0}, {1}, {2}, {3}", factura.Codigo, factura.Tiempo, factura.Estatus, factura.Tienda);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }
        [HttpPost("detalle/{factura}")]
        public ActionResult Post(string factura, [FromBody] ProductoFactura producto){
            try{
                var generator = new RandomGenerator();
                producto.Codigo = "PF"+generator.RandomString(8);
                context.Database.ExecuteSqlRaw("EXEC agregarProductosFacturas {0}, {1}, {2}, {3}, {4}, {5}, {6}", producto.Codigo, producto.ProductoCodigo, factura, producto.Cantidad, producto.Precio, producto.Descuento, producto.Impuesto);
                //create procedure agregarProductosFacturas @codigo, @productotienda, @factura, @cantidad, @precio, @descuento, @impuesto
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }

        //create procedure modificarFactura @codigo varchar(10), @tiempoFacturacion datetime2, @estatus varchar(4) as
        [HttpPut("{codigo}")]
        public ActionResult Put(string codigo, [FromBody] Factura factura){
            try{
                context.Database.ExecuteSqlRaw("EXEC modificarFactura {0}, {1}, {2}", codigo, factura.Tiempo, factura.Estatus);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }

        [HttpPut("detalle/{factura}/{producto}")]
        public ActionResult Put(string factura, string producto, [FromBody] ProductoFactura productodetalle){
            try{
                context.Database.ExecuteSqlRaw("EXEC modificarProductosFacturas {0}, {1}, {2}, {3}, {4}, {5}, {6}", producto, productodetalle.ProductoCodigo, factura, productodetalle.Cantidad, productodetalle.Precio, productodetalle.Descuento, productodetalle.Impuesto);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex);
            } 
        }

        //create procedure modificarProductosFacturas @codigo varchar(10), @productotienda varchar(10), @factura varchar(10), @cantidad decimal(10), @precio decimal(10,2), @descuento decimal(10,2), @impuesto decimal(10,2) as
        //update productosFacturas set producto = @productotienda, cantidad = @cantidad, precio = @precio, descuento = @descuento, impuesto = @impuesto where codigo = @codigo and factura = @factura


        [HttpDelete("detalle/{factura}/{producto}/{estado}")]
        public ActionResult Delete(string factura, string producto, string estado){
            try{
                if(estado == "ACTIVO"){
                    context.Database.ExecuteSqlRaw("EXEC activarProductosFacturas {0}, {1}", producto, factura);
                }
                if(estado == "INACTIVO"){
                    context.Database.ExecuteSqlRaw("EXEC quitarProductosFacturas {0}, {1}", producto, factura);
                }
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex);
            } 

        }
    }
}