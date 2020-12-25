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
    public class EstatusFacturaController : Controller
    {
        private readonly AplicationDBContext context;
        public EstatusFacturaController(AplicationDBContext context){
            this.context = context;

        }

        [HttpGet]
        public ActionResult<EstatusFactura> Get(){
            try{
                var estatuslista = context.FacturaEstatus.ToList();
                if(estatuslista == null){
                    return NotFound();
                }
                return Ok(estatuslista);
            }catch(Exception ex){
                return BadRequest(ex);
            }   
        }

    }
}