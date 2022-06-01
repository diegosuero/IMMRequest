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
    public class SolicitudController : ControllerBase 
    {
        private ILogic<Solicitud> repoSolicitud;

        public SolicitudController(ILogic<Solicitud> rs){
            this.repoSolicitud=rs;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<Solicitud>> Get()
        {
            return Ok(repoSolicitud.GetAll().ToList()); 
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try{
                var solicitud = repoSolicitud.Get(id);
                if (solicitud !=null){
                    return Ok(SolicitudModel.ToModel(solicitud));
                }
                return NotFound();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] SolicitudModel solicitud)
        {
            try{
                var sol=repoSolicitud.Create(SolicitudModel.ToEntity(solicitud));
                return Ok(sol.Id);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [AuthFilter]
        [HttpPut("{id}")]
        public ActionResult<int> Put([FromHeader]int auth, int id,[FromBody] SolicitudModel solicitudM)
        {
            try{
                Solicitud solicitud = repoSolicitud.Get(id);
                solicitud.CambiarEstado(solicitudM.Estado);
                solicitud.Descripcion=solicitudM.Descripcion;
                repoSolicitud.Update(id,solicitud);
                return Ok(solicitud.Id);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
          
    }
}