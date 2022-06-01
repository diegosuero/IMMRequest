using System;
using System.Collections.Generic;

namespace IMMRequest.Domain
{
    public class CampoAdicionalEntero : CampoAdicional
    {
        public List<ValorEntero> valores;
        public int cotaInferior;
        public int cotaSuperior;

        private Boolean rangoVacio = true;

        public CampoAdicionalEntero(String nombre)
        {
            this.Nombre=nombre;
            this.Tipo = "Entero";
            valores=new List<ValorEntero>();
        }

        public CampoAdicionalEntero()
        {
            this.Tipo = "Entero";
            valores=new List<ValorEntero>();
        }
        public CampoAdicionalEntero(String nombre,List<ValorEntero> lista, int cotaInferior, int cotaSuperior)
        {
            for(int i = 0; i<lista.Count;i++){
                if (dentroDeRango(lista[i].valor,cotaInferior,cotaSuperior)){
                this.Nombre=nombre;
                this.cotaInferior=cotaInferior;
                this.cotaSuperior=cotaSuperior;
                this.rangoVacio=false;
                this.Tipo = "Entero";
                }else{
                    throw new Exception("Valor fuera de rango");
                }
            }
            
        }
        public bool dentroDeRango(int valor)
        {
            if (!this.rangoVacio)
            {
                return valor>=this.cotaInferior || valor<=this.cotaSuperior;
            }
            return true;
        }
        public bool dentroDeRango(int valor, int cotaInferior, int cotaSuperior)
        {
                    return validarCotas(cotaInferior,cotaSuperior)&&valor>=cotaInferior || valor<=cotaSuperior;
        }

        public override void setearValor(List<ValorEntero> lista)
        {
            for(int i = 0; i<lista.Count;i++){
                if (dentroDeRango(lista[i].valor))
                {
                    this.valores.Add(lista[i]);
                }else{
                    throw new Exception("Valor fuera de rango");
                }
            }
        }

        private Boolean validarCotas(int cotaInferior, int cotaSuperior){
            if (!(cotaInferior>cotaSuperior)){
                throw new Exception("Cota inferior mas grande que la superior");
            }else{
                return true;
            }
        }

        public override void setearRango(int cotaInferior, int cotaSuperior){
            if (validarCotas(cotaInferior,cotaSuperior)){
                    this.cotaInferior=cotaInferior;
                    this.cotaSuperior=cotaSuperior;
                    this.rangoVacio=false;
                    
            }
        }
    }
}