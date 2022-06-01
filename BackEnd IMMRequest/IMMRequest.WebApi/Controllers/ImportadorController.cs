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
using IMMRequest.BusinessLogic;

namespace IMMRequest.WebApi.Controllers
{
    [Route("[controller]")] 
    [ApiController] 
    public class ImportadorController : ControllerBase 
    {
            private ImportadorLogic importadorLogic;


        public ImportadorController(ImportadorLogic importadorLogic){
            this.importadorLogic= importadorLogic;
        }

        [HttpPost]

        public ActionResult<string> Post([FromHeader] string path,[FromHeader] string aImportar,[FromHeader] string nombreImportador)
        {
            try{
                importadorLogic.Importar(path,nombreImportador,aImportar);
                return Ok("Se importo Correctamente");

            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet] 
        public ActionResult<IEnumerable<string>> Get()
        {
            try{
                return Ok(importadorLogic.getImportadores());
            }catch(Exception e){
                return BadRequest(e.Message);
            }            
        }
        
    }
}