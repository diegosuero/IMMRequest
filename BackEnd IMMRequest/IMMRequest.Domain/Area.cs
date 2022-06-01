using System;
using System.Collections.Generic;

namespace IMMRequest.Domain
{
    public class Area
    {
        public Area()
        {
        }

        public Area(string nombre)
        {
            Nombre = nombre;
        }

        public int Id{get ; set; }
        public String Nombre{get ; set; }

        public List<Tema> Temas{get ; set; }

        public void seteartemas(List<Tema> temas){
            Temas= temas;
        }

         public void agregartema(Tema tema){
            if(tema.Nombre!=""){
                    if (!Temas.Exists(x=> x.Nombre==tema.Nombre)){
                        Temas.Add(tema);
                        
                    }else{
                        throw new ArgumentException("Ya existe un Tema con ese nombre");
                    }
                }else{
                        throw new ArgumentException("El Nombre del Tema no puede ser vacio");
                }
        }
    }
}
