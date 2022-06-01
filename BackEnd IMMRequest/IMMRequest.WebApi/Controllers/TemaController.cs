using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.Domain;
using Microsoft.AspNetCore.Mvc;
using IMMRequest.WebApi.Models;
using IMMRequest.WebApi.Filters;
using Microsoft.AspNetCore.Cors;

namespace IMMRequest.WebApi.Controllers
{
    [Route("[controller]")] 
    [ApiController]
    public class TemaController : ControllerBase 
    {
        private ILogic<Tema> Tema;
        

        public TemaController(ILogic<Tema> Tema)
        {
            this.Tema = Tema;
        }
        
        // GET api/administrador

        [HttpGet] 
        public ActionResult<IEnumerable<Tema>> Get()
        {
            return Tema.GetAll().ToList();
            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try{
                var tema = Tema.Get(id);
                if (tema !=null){
                    return Ok(tema);
                }
                return NotFound();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}