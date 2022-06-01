using System;

namespace IMMRequest.Domain
{
    public class CampoAdicionalBooleano : CampoAdicional
    {
        public Boolean valor;


        public CampoAdicionalBooleano(String nombre)
        {
            this.Nombre=nombre;
            this.Tipo = "Booleano";
        }

        public CampoAdicionalBooleano()
        {
            this.Tipo = "Booleano";
        }
        public CampoAdicionalBooleano(String nombre,Boolean valor)
        {
                this.Nombre=nombre;
                this.Tipo = "Booleano";
        }

        public override void setearValor(Boolean valor)
        {
            this.valor=valor;
        }
    }
}