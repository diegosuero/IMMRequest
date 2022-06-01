using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class CampoAdicionalBooleanoRepository : IRepository<CampoAdicionalBooleano>
    {

           protected DbContext Context {get; set;}
        public CampoAdicionalBooleanoRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(CampoAdicionalBooleano entity)
        {
            Context.Set<CampoAdicionalBooleano>().Add(entity);
        }

        public void Remove(CampoAdicionalBooleano entity)
        {
            try{
                 CampoAdicionalBooleano c = Get(entity.Id);
                 Context.Set<CampoAdicionalBooleano>().Remove(c);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public void Update(CampoAdicionalBooleano entity)
        {
            bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public IEnumerable<CampoAdicionalBooleano> GetAll()
        {
            return Context.Set<CampoAdicionalBooleano>().ToList();
        }

        public CampoAdicionalBooleano Get(int id)
        {
             try{
                return Context.Set<CampoAdicionalBooleano>()
                    .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public CampoAdicionalBooleano GetByString(string txt)
        {
            try{
                return Context.Set<CampoAdicionalBooleano>()
                    .First(x => x.Nombre == txt);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}