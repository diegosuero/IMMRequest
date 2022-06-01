using System;
using System.Collections.Generic;
namespace IMMRequest.Domain
{
    public class ValorFecha
    {
        public ValorFecha()
        {
        }

        public ValorFecha(int id, DateTime fecha)
        {
            this.id = id;
            this.fecha = fecha;
        }

        public int id{get;set;}
        public DateTime fecha {get;set;}
    }
}