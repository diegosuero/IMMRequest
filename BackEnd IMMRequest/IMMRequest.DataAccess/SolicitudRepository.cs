using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class SolicitudRepository : IRepository<Solicitud>
    {
        protected DbContext Context {get; set;}
        public SolicitudRepository(DbContext context)
        {
            Context = context;
        }

        public  Solicitud Get(int id)
        {
             try{
                   return Context.Set<Solicitud>().Include(x => x.Tema).Include(x=>x.Area).Include(x=>x.Tipo).Include(x=>x.CamposAdicionales)
                .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("La Solicitud no existe");
            }
           
        }
        public IEnumerable<Solicitud> GetAll()
        {
            return Context.Set<Solicitud>().Include(x => x.Tema).Include(x=>x.Area).Include(x=>x.Tipo).Include(x=>x.CamposAdicionales).ToList();
        }

        public Solicitud GetByString(String txt)
        {
            try{
                return Context.Set<Solicitud>().Include(x => x.Tema).Include(x=>x.Area).Include(x=>x.Tipo).Include(x=>x.CamposAdicionales)
                    .First(x => x.mail == txt);
            }catch(Exception){
                throw new KeyNotFoundException("La Solicitud no existe");
            }
        }

        public void Add(Solicitud entity)
        {
            Context.Set<Solicitud>().Add(entity);
        }

        public void Remove(Solicitud entity)
        {
            try{
                 Solicitud a = Get(entity.Id);
                 Context.Set<Solicitud>().Remove(entity);
            }catch(Exception){
                throw new KeyNotFoundException("La Solicitud no existe");
            }
        }

        public void Update(Solicitud entity)
        {
            bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("La Solicitud no existe");
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}