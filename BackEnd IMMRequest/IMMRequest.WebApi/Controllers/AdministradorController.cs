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
    
    public class AdministradorController : ControllerBase 
    {
        private ILogic<Administrador> administrador;
        

        public AdministradorController(ILogic<Administrador> admin)
        {
            this.administrador = admin;
        }
        
        // GET api/administrador

        [HttpGet] 
        public ActionResult<IEnumerable<Administrador>> Get()
        {
            return administrador.GetAll().ToList();
            
        }

        // GET api/Administrador/5
        [AuthFilter]
        [HttpGet("{id}")]

        public IActionResult Get([FromHeader]int auth ,int id)
        {
            try{
                var admin = administrador.Get(id);
                if (admin !=null){
                    return Ok(AdminModel.ToModel(admin));
                }
                return NotFound();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // POST api/Administrador
        [AuthFilter]
        [HttpPost]
        public ActionResult<int> Post([FromHeader]int auth ,[FromBody] AdminModel admin)
        {
            try{
                var admins = administrador.Create(AdminModel.ToEntity(admin));
                return admins.Id;
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // PUT api/Administrador/5
        [AuthFilter]
        [HttpPut("{id}")]
        public ActionResult<int> Put([FromHeader]int auth ,int id, [FromBody] AdminModel admin)
        {
             try{
                administrador.Update(id,AdminModel.ToEntity(admin));
                return Ok("ok");
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        // DELETE api/Administrador/5
        [AuthFilter]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromHeader]int auth ,int id)
        {
            try{
                administrador.Remove(id);
                return Ok("Se borro el Admin " +id);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        
        
    }

    
}