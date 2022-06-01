using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class CampoAdicionalFechaRepository : IRepository<CampoAdicionalFecha>
    {

           protected DbContext Context {get; set;}
        public CampoAdicionalFechaRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(CampoAdicionalFecha entity)
        {
            Context.Set<CampoAdicionalFecha>().Add(entity);
        }

        public void Remove(CampoAdicionalFecha entity)
        {
            try{
                 CampoAdicionalFecha c = Get(entity.Id);
                 Context.Set<CampoAdicionalFecha>().Remove(c);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public void Update(CampoAdicionalFecha entity)
        {
            bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public IEnumerable<CampoAdicionalFecha> GetAll()
        {
            return Context.Set<CampoAdicionalFecha>().Include(x=> x.valores).ToList();
        }

        public CampoAdicionalFecha Get(int id)
        {
             try{
                return Context.Set<CampoAdicionalFecha>().Include(x=> x.valores)
                    .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public CampoAdicionalFecha GetByString(string txt)
        {
            try{
                return Context.Set<CampoAdicionalFecha>().Include(x=> x.valores)
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