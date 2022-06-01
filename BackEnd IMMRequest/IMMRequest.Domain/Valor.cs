using System;
using System.Collections.Generic;
namespace IMMRequest.Domain
{
    public class Valor
    {
        public Valor()
        {
        }

        public Valor(int id, string texto)
        {
            this.id = id;
            this.texto = texto;
        }

        public int id{get;set;}
        public String texto{get;set;}
    }
}