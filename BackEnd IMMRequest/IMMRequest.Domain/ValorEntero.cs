using System;
using System.Collections.Generic;
namespace IMMRequest.Domain
{
    public class ValorEntero
    {
        public ValorEntero()
        {
        }

        public ValorEntero(int id, int valor)
        {
            this.id = id;
            this.valor = valor;
        }

        public int id{get;set;}
        public int valor {get;set;}
    }
}