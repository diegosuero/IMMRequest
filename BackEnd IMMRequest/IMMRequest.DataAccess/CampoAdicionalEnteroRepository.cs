using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class CampoAdicionalEnteroRepository : IRepository<CampoAdicionalEntero>
    {

           protected DbContext Context {get; set;}
        public CampoAdicionalEnteroRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(CampoAdicionalEntero entity)
        {
            Context.Set<CampoAdicionalEntero>().Add(entity);
        }

        public void Remove(CampoAdicionalEntero entity)
        {
            try{
                 CampoAdicionalEntero c = Get(entity.Id);
                 Context.Set<CampoAdicionalEntero>().Remove(c);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public void Update(CampoAdicionalEntero entity)
        {
            bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public IEnumerable<CampoAdicionalEntero> GetAll()
        {
            return Context.Set<CampoAdicionalEntero>().Include(x => x.valores).ToList();
        }

        public CampoAdicionalEntero Get(int id)
        {
             try{
                return Context.Set<CampoAdicionalEntero>().Include(x => x.valores)
                    .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public CampoAdicionalEntero GetByString(string txt)
        {
            try{
                return Context.Set<CampoAdicionalEntero>().Include(x => x.valores)
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