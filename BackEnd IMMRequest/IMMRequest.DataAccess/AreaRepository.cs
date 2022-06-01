using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class AreaRepository : IRepository<Area>
    {
        protected DbContext Context {get; set;}
        public AreaRepository(DbContext context)
        {
            Context = context;
        }

        public Area Get(int id)
        {
            try{
                return Context.Set<Area>().Include(x => x.Temas)
                    .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("El Area no existe");
            }
           
        }
        public IEnumerable<Area> GetAll()
        {
            return Context.Set<Area>().Include(x => x.Temas).ToList();
        }

        public Area GetByString(String txt)
        {
            try{
                return Context.Set<Area>().Include(x => x.Temas)
                    .First(x => x.Nombre == txt);
            }catch(Exception){
                throw new KeyNotFoundException("El area no existe ");
            }
        }

        public void Add(Area entity)
        {
            Context.Set<Area>().Add(entity);
        }

        public void Remove(Area entity)
        {
            try{
                 Area a = Get(entity.Id);
                 Context.Set<Area>().Remove(entity);
            }catch(Exception){
                throw new KeyNotFoundException("El area no existe");
            }
        }

        public void Update(Area entity)
        {
            bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("El area no existe");
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}