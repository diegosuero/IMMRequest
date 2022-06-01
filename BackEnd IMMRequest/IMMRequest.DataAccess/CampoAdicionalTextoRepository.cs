using System;
using System.Collections.Generic;
using System.Linq;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class CampoAdicionalTextoRepository : IRepository<CampoAicionalTexto>
    {

           protected DbContext Context {get; set;}
        public CampoAdicionalTextoRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(CampoAicionalTexto entity)
        {
            Context.Set<CampoAicionalTexto>().Add(entity);
        }

        public void Remove(CampoAicionalTexto entity)
        {
            try{
                 CampoAicionalTexto c = Get(entity.Id);
                 Context.Set<CampoAicionalTexto>().Remove(c);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public void Update(CampoAicionalTexto entity)
        {
            bool existe = Get(entity.Id)!=null;
            if(true){
                Context.Entry(entity).State = EntityState.Modified;
                Save();
            }else{
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public IEnumerable<CampoAicionalTexto> GetAll()
        {
            return Context.Set<CampoAicionalTexto>().Include(x => x.valores).Include(x=> x.valoresRango).ToList();
        }

        public CampoAicionalTexto Get(int id)
        {
             try{
                return Context.Set<CampoAicionalTexto>().Include(x => x.valores).Include(x=> x.valoresRango)
                    .First(x => x.Id == id);
            }catch(Exception){
                throw new KeyNotFoundException("El Campo no existe");
            }
        }

        public CampoAicionalTexto GetByString(string txt)
        {
            try{
                return Context.Set<CampoAicionalTexto>().Include(x => x.valores).Include(x=> x.valoresRango)
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