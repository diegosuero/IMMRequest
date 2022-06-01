using IMMRequest.Domain;
using System;
using System.Collections.Generic;
using IMMRequest.WebApi.Models;
namespace IMMRequest.WebApi.Models
{
    public class SolicitudModel : Model<Solicitud, SolicitudModel>
    {
        public String nombre{get ; set; }
        public String mail{get ; set; }
        public String telefono{get ; set; }
        public String Detalle{get ; set; }
        public String Area{get ; set; }
        public String Tema {get ; set; }
        public String Tipo {get ; set; }
        public String Estado {get ; set; }

        public DateTime fechaIngreso {get ; set; }
        public String Descripcion {get ; set; }

    

        public List<CampoAdicional> CamposAdicionales{get ; set; }


        public SolicitudModel()
        {
        }

        public SolicitudModel(Solicitud solicitud)
        {
            SetModel(solicitud);
        }

        public override Solicitud ToEntity()=> new Solicitud()
        {
            nombre = this.nombre,
            mail=this.mail,
            telefono=this.telefono,
            Tema=new Tema(){
                Nombre = this.Tema
            },
            Tipo=new TipoDeTema(){
                nombre =this.Tipo
            },
            Detalle=this.Detalle,
            Area=new Area(this.Area),
            Estado=this.Estado,
            Descripcion=this.Descripcion,
            fechaIngreso=this.fechaIngreso,
            CamposAdicionales=this.CamposAdicionales
        };

        
      

        public void DeConcatenarListas(List<CampoAdicional> lista){
            this.CamposAdicionales=lista;
        }
    
        protected override SolicitudModel SetModel(Solicitud entity)
        {
            nombre = entity.nombre;
            mail=entity.mail;
            telefono=entity.telefono;
            Descripcion=entity.Descripcion;
            Tema=entity.Tema.Nombre;
            Tipo=entity.Tipo.nombre;
            Detalle=entity.Detalle;
            Area=entity.Area.Nombre;
            DeConcatenarListas(entity.Tipo.Campos);
            Estado=entity.Estado;
            fechaIngreso=entity.fechaIngreso;
            return this;
        }
    }
}