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
    public class AreaController : ControllerBase 
    {
        private ILogic<Area> area;
        

        public AreaController(ILogic<Area> area)
        {
            this.area = area;
        }
        
        // GET api/administrador

        [HttpGet] 
        public ActionResult<IEnumerable<Area>> Get()
        {
            return area.GetAll().ToList();
            
        }
    }
}