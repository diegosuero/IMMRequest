using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class SessionsRepository : IRepository<AdminSession>
    {
        protected DbContext Context {get; set;}
        public SessionsRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(AdminSession entity)
        {
             Context.Set<AdminSession>().Add(entity);
        }

        public AdminSession Get(int id)
        {
            try{
                  return Context.Set<AdminSession>().Include(x => x.admin)
                .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("La Sesion no existe");
            }
        }

        public IEnumerable<AdminSession> GetAll()
        {
            return Context.Set<AdminSession>().Include(x=> x.admin).ToList();
        }

        public AdminSession GetByString(string txt)
        {
            try{
                int token = Int32.Parse(txt);
                return Context.Set<AdminSession>().Include(x => x.admin)
                    .First(x => x.Token == token);
            }catch(Exception){
                throw new KeyNotFoundException("La Sesion no existe");
            }
        }

         public AdminSession GetByEmail(string email)
        {
            try{
                return Context.Set<AdminSession>().Include(x => x.admin)
                    .First(x => x.admin.Email == email);
            }catch(Exception){
                throw new KeyNotFoundException("La Sesion no existe");
            }
        }



        public void Remove(AdminSession entity)
        {
           try{
                 AdminSession a = Get(entity.Id);
                 Context.Set<AdminSession>().Remove(entity);
            }catch(Exception){
                throw new KeyNotFoundException("La Sesion no existe");
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(AdminSession entity)
        {
            bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("La Sesion no existe");
            }
        }
    }
}