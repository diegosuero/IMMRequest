using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class TipoRepository : IRepository<TipoDeTema>
    {
        protected DbContext Context {get; set;}
        public TipoRepository(DbContext context) 
        {
            this.Context = context;
               
        }

        public TipoDeTema Get(int id)
        {
            try{
                return Context.Set<TipoDeTema>().Include(x => x.Campos)
                    .First(x => x.ID == id);
            }catch(Exception){
                throw new KeyNotFoundException("El Tipo no existe");
            }
           
        }
        public IEnumerable<TipoDeTema> GetAll()
        {
            return Context.Set<TipoDeTema>().Include(x => x.Campos).ToList();
        }

        public TipoDeTema GetByString(string txt)
        {
            try{
                return Context.Set<TipoDeTema>().Include(x => x.Campos)
                    .First(x => x.nombre == txt);
            }catch(Exception){
                throw new KeyNotFoundException("El tipo no existe");
            }
        }

        public void Add(TipoDeTema entity)
        {
            Context.Set<TipoDeTema>().Add(entity);
        }

        public void Remove(TipoDeTema entity)
        {
            try{
                 TipoDeTema t = Get(entity.ID);
                 Context.Set<TipoDeTema>().Remove(entity);
            }catch(Exception){
                throw new KeyNotFoundException("El Tipo no existe");
            }
        }

        public void Update(TipoDeTema entity)
        {
            bool existe = Get(entity.ID)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("El Tipo no existe");
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }



                
        
}
