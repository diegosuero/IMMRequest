using IMMRequest.Domain;
using System;
using System.Collections.Generic;
using IMMRequest.WebApi.Models;
namespace IMMRequest.WebApi.Models
{
    public class TipoModel : Model<TipoDeTema, TipoModel>
    {
        public TipoModel()
        {
        }

        public TipoModel(TipoDeTema tipo)
        {
            SetModel(tipo);
        }

        public String Area{get ; set; }
        public String Tema{get ; set; }

        public String Tipo{get ; set; }
        public Boolean Activo{get ; set; }

        public List<CampoAdicional> camposAdicionales{get ; set; }

        public override TipoDeTema ToEntity()=> new TipoDeTema()
        {
            nombre= Tipo,
            Activo = Activo,
            Campos=camposAdicionales
        };

        protected override TipoModel SetModel(TipoDeTema entity)
        {
            Tipo = entity.nombre;
            Activo = entity.Activo;
            camposAdicionales=entity.Campos;
            return this;
        }
    }
}