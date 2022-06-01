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
    public class TipoController : ControllerBase 
    {
            private ILogic<Area> repoArea;
            private ILogic<Tema> repoTema;

            private ILogic<TipoDeTema> repoTipoTema;

            private ILogic<CampoAdicionalBooleano> LogicBool;
            private ILogic<CampoAdicionalEntero> LogicEntero;
            private ILogic<CampoAdicionalFecha> LogicFecha;
            private ILogic<CampoAicionalTexto> LogicTexto;


            public TipoController(ILogic<Area> logicArea,ILogic<TipoDeTema> logictipo,ILogic<Tema> LogicTema,ILogic<CampoAdicionalBooleano> LogicBool ,
                    ILogic<CampoAdicionalEntero> LogicEntero,ILogic<CampoAdicionalFecha> LogicFecha,ILogic<CampoAicionalTexto> LogicTexto){
            this.repoArea=logicArea;
            this.repoTema=LogicTema;
            this.repoTipoTema=logictipo;
            this.LogicBool=LogicBool;
            this.LogicEntero=LogicEntero;
            this.LogicFecha=LogicFecha;
            this.LogicTexto=LogicTexto;

        }

        [AuthFilter]
        [HttpPost]

        public ActionResult<int> Post([FromHeader]int auth,[FromBody] TipoModel tipo)
        {
            try{
                Area area = repoArea.GetByString(tipo.Area);
                List<Tema> t = area.Temas;
                Tema temaCompleto=repoTema.Get(t.First(x=> x.Nombre == tipo.Tema).Id);
                TipoDeTema tipoAagregar = new TipoDeTema(){
                    nombre=tipo.Tipo,
                    //Campos=tipo.camposAdicionales,
                    Activo = tipo.Activo
                };
                temaCompleto.AgregarTipo(tipoAagregar);
                 for(int i =0;i<tipoAagregar.Campos.Count;i++){
                     
                    CampoAdicional c = tipoAagregar.Campos[i];
                    if(c.Tipo=="Entero"){        
                                        LogicEntero.Create((CampoAdicionalEntero)c);
                    }if(c.Tipo=="Fecha"){
                                        LogicFecha.Create((CampoAdicionalFecha)c);
                    }if(c.Tipo=="Booleano"){ 
                                        LogicBool.Create((CampoAdicionalBooleano)c);
                    }if(c.Tipo=="Texto"){ 
                                        LogicTexto.Create((CampoAicionalTexto)c);
                    }
                }
                repoArea.Update(area.Id,area);
                return Ok(tipoAagregar.ID);

            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        [AuthFilter]
        [HttpPut]
        public ActionResult<int> Put([FromHeader]int auth ,[FromBody] TipoModel tipo)
        {
             try{
                Area area = repoArea.GetByString(tipo.Area);
                List<Tema> t = area.Temas;
                Tema temaCompleto=repoTema.Get(t.First(x=> x.Nombre==tipo.Tema).Id);
                TipoDeTema tipoCompleto=repoTipoTema.Get(temaCompleto.Tipos.First(x=> x.nombre==tipo.Tipo).ID);
                tipoCompleto.Activo=tipo.Activo;
                tipoCompleto.AgregarCampos(tipo.camposAdicionales);
                repoTipoTema.Update(tipoCompleto.ID,tipoCompleto);
                return Ok(temaCompleto.Id);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet] 
        public ActionResult<string> Get()
        {
            TipoDeTema t = repoTipoTema.Get(2004);
            List<CampoAdicional> a = new List<CampoAdicional>();

            
            CampoAicionalTexto c =  new CampoAicionalTexto();
            c.Nombre="TEsttt";
            Valor v = new Valor(2,"valor real");
            c.valores.Add(v);
             Valor v2 = new Valor(1,"valor rango");
             c.valoresRango.Add(v2);
             a.Add(c);
            t.AgregarCampos(a);

             LogicTexto.Create(c);
            return c.GetType().ToString();            
        }
        
    }
}