using System;
using System.Collections.Generic;

namespace IMMRequest.Domain
{
    public class CampoAicionalTexto : CampoAdicional
    {
        public List<Valor> valores{get;set;}
        public List<Valor> valoresRango {get;set;}

        public CampoAicionalTexto(){
            this.Tipo = "Texto";
            this.valoresRango=new List<Valor>();
            this.valores=new List<Valor>();
        }

 

        public override void setearValor(List<Valor> valores)
        {
            for(int i =0;i<valores.Count;i++){
                if(dentroDeRango(valores[i].texto)){
                    this.valores.Add(valores[i]);
                }else{
                    throw new Exception("Valor fuera de rango");
                }
            }
        }

        public bool dentroDeRango(String valor)
        {
            for (int i = 0; i < valoresRango.Count; i++)
            {
                Valor v = valoresRango[i];
                if(v.texto==valor){
                    return true;
                }
            }
            return false;
        }
    }
}