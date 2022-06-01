using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class AdministradorRepository : IRepository<Administrador>
    {
        protected DbContext Context {get; set;}
        public AdministradorRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(Administrador entity)
        {
             Context.Set<Administrador>().Add(entity);
        }

        public void Remove(Administrador entity)
        {
            try{
                 Administrador a = Get(entity.Id);
                 Context.Set<Administrador>().Remove(entity);
            }catch(Exception){
                throw new KeyNotFoundException("El Administrador no existe");
            }
        }

        public void Update(Administrador entity)
        {
            bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("El Administrador no existe");
            }
        }

        public IEnumerable<Administrador> GetAll()
        {
            return Context.Set<Administrador>().ToList();
        }

        public Administrador Get(int id)
        {
            try{
                 return Context.Set<Administrador>()
                .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("El Administrador no existe");
            }
        }

        public Administrador GetByString(string txt)
        {
            try{
                return Context.Set<Administrador>()
                    .First(x => x.Email == txt);
            }catch(Exception){
                throw new KeyNotFoundException("El Administrador no existe");
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}