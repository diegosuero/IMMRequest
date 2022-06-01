using System;
using System.Collections.Generic;

namespace IMMRequest.Domain
{
    public class Tema
    {
        public Tema()
        {
            Tipos = new List<TipoDeTema>();
        }

        public int Id {get ; set; }
        public String Nombre{get ; set; }
        public List<TipoDeTema> Tipos {get ; set; }

        public void AgregarTipo(TipoDeTema tipo){
                if(tipo.nombre!=""){
                    if (!Tipos.Exists(x=> x.nombre==tipo.nombre)){
                        Tipos.Add(tipo);
                        
                    }else{
                        throw new ArgumentException("Ya existe un Tipo con ese nombre");
                    }
                }else{
                        throw new ArgumentException("El Nombre del Tipo no puede ser vacio");
                }
                
        }
        
    }
}
