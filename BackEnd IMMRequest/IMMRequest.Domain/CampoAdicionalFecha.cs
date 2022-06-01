using System;
using System.Collections.Generic;

namespace IMMRequest.Domain
{
    public class CampoAdicionalFecha : CampoAdicional
    {
        public List<ValorFecha> valores;
        public DateTime cotaInferior;
        public DateTime cotaSuperior;

        private Boolean rangoVacio = true;
        public CampoAdicionalFecha(String nombre)
        {
            this.Nombre = nombre;
            this.Tipo = "Fecha";
        }

        public CampoAdicionalFecha()
        {
            this.Tipo = "Fecha";
        }

        public CampoAdicionalFecha(String nombre, List<ValorFecha> valores,DateTime cotaInferior, DateTime cotaSuperior)
        {
            for(int i =0;i<valores.Count;i++){
                if (dentroDeRango(valores[i].fecha,cotaInferior,cotaSuperior)){
                this.Nombre=nombre;
                this.cotaInferior=cotaInferior;
                this.cotaSuperior=cotaSuperior;
                this.rangoVacio=false;
                this.Tipo = "Fecha";
            }else{
                throw new Exception("Valor fuera de rango");
            }
            }
            
        }

        public override void setearValor(List<ValorFecha> valores)
        {
             for(int i =0;i<valores.Count;i++){
                if(dentroDeRango(valores[i].fecha)){
                    this.valores.Add(valores[i]);
                }else{
                        throw new Exception("Valor fuera de rango");
                }
            }
        }

        public override void setearRango(DateTime cotaInferior, DateTime cotaSuperior){
            if (validarCotas(cotaInferior,cotaSuperior)){
                this.cotaInferior=cotaInferior;
                this.cotaSuperior=cotaSuperior;
                this.rangoVacio=false;
            }

        }

        private Boolean validarCotas(DateTime cotaInferior, DateTime cotaSuperior){
            if (!(cotaInferior>cotaSuperior)){
                throw new ArgumentException("Cota inferior mas grande que la superior");
            }else{
                return true;
            }
        }

        public bool dentroDeRango(DateTime valor)
        {
            if (!this.rangoVacio)
            {
                return valor>=this.cotaInferior || valor<=this.cotaSuperior;
            }
            return true;
        }

        public bool dentroDeRango(DateTime valor, DateTime cotaInferior, DateTime cotaSuperior)
        {
                    return validarCotas(cotaInferior,cotaSuperior)&&valor>=cotaInferior || valor<=cotaSuperior;
        }
    }
}