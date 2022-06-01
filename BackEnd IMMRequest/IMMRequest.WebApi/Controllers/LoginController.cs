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
    
    public class LoginController: ControllerBase 
    {

        private ISession<AdminSession> sesion;

        public LoginController(ISession<AdminSession> sesionLogic)
        {
            this.sesion=sesionLogic;
        }

        
        [HttpPost(Name = "Login")]
        public ActionResult<int> PostLogin([FromBody] LoginModel login)
        {
            try{
                return Ok(sesion.Login(login.email,login.password));
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(int token)
        {
            try{
                var AdminSession = sesion.estaLogueado(token);
               if (AdminSession){
                    return Ok(sesion.GetAll().First(x=> x.Token==token).Id);
                }
                return NotFound();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}