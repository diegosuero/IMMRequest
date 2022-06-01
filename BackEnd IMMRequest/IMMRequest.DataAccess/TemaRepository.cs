using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class TemaRepository: IRepository<Tema>
    {
        protected DbContext Context {get; set;}
        public TemaRepository(DbContext context) 
        {
            this.Context = context;
               
        }

        public void Add(Tema entity)
        {
            Context.Set<Tema>().Add(entity);
        }

        public void Remove(Tema entity)
        {
            try{
                 Tema t = Get(entity.Id);
                 Context.Set<Tema>().Remove(entity);
            }catch(Exception){
                throw new KeyNotFoundException("El Tema no existe");
            }
        }

        public void Update(Tema entity)
        {
             bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("El Tema no existe");
            }
        }

        public IEnumerable<Tema> GetAll()
        {
            return Context.Set<Tema>().Include(x => x.Tipos).ToList();
        }

        public Tema Get(int id)
        {
            try{
                return Context.Set<Tema>().Include(x => x.Tipos)
                    .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("El Tema no existe");
            }
        }

        public Tema GetByString(string txt)
        {
            try{
                return Context.Set<Tema>().Include(x => x.Tipos)
                    .First(x => x.Nombre == txt);
            }catch(Exception){
                throw new KeyNotFoundException("El Tema no existe");
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}