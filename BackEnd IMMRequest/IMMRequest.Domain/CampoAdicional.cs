using System;
using System.Collections.Generic;

namespace IMMRequest.Domain
{
    public abstract class CampoAdicional
    {
        protected CampoAdicional()
        {
        }

        public int Id {get ; set; }

        public String Nombre{get ; set; }
        public String Tipo{get ; set; }
        public virtual void setearValor(List<ValorEntero> lista){
            throw new NotImplementedException();
        }
        public virtual void setearValor(List<ValorFecha> valores){
            throw new NotImplementedException();
        }
        public virtual void setearValor(List<Valor> valores){
            throw new NotImplementedException();
        }

        public virtual void setearValor(Boolean valor){
            throw new NotImplementedException();
        }


         public virtual void setearRango(int cotaInferior, int cotaSuperior){
             throw new NotImplementedException();
        }
        public virtual void setearRango(DateTime cotaInferior, DateTime cotaSuperior){
            throw new NotImplementedException();
        }
        public virtual void setearRango(List<String> valor){
            throw new NotImplementedException();
        }

        

    }
}
