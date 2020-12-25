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
    public class TipoUsuarioController : Controller
    {
        private readonly AplicationDBContext context;
        public TipoUsuarioController(AplicationDBContext context){
            this.context = context;

        }
        [HttpGet]
        public ActionResult<List<TipoUsuario>> Get(){
            try{
                var tipos = context.TipoUsuarios.ToList();
                if(tipos == null){
                    return NotFound();
                }
                return Ok(tipos);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
    }
}