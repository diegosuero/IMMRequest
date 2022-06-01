using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMMRequest.DataAccess
{
    public class IMMRequestContext : DbContext
    {
        public DbSet<Area> Areas {get; set;}
        public DbSet<Administrador> Administradores {get; set;}
        public DbSet<Solicitud> Solicitudes {get; set;}
        public DbSet<CampoAdicionalEntero> CampoAdicionalesEntero {get; set;}
        public DbSet<CampoAdicionalFecha> CampoAdicionalesFecha {get; set;}
        public DbSet<CampoAicionalTexto> CampoAdicionalesTexto {get; set;}

        public DbSet<AdminSession> Sessions { get; set; }

        //public DbSet<String> Strings { get; set; }

        public IMMRequestContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}