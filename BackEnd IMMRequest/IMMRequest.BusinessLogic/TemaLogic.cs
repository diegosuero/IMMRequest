using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    public class TemaLogic : ILogic<Tema>
    {
        private IRepository<Tema> repository;

        public TemaLogic(IRepository<Tema> repository)
        {
            this.repository = repository;
        }

        public Tema Create(Tema entity)
        {
            ThrowErrorIfItsInvalid(entity);
            repository.Add(entity);
            repository.Save();
           
           return entity;
        }

        public Tema Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception){
                throw new ArgumentException("No existe ese Tema");
            }
        }

        public IEnumerable<Tema> GetAll()
        {
            return repository.GetAll();
        }

        public void Remove(int id)
        {
             try{
                Tema Tema = Get(id);
                repository.Remove(Tema);
                repository.Save();
            }catch(Exception){
                throw new ArgumentException("No existe ese Tema");
            }
        }

        public Tema Update(int id, Tema entity)
        {
            try{
                repository.Update(entity);
                repository.Save();
                return entity;
            }catch(Exception){
                throw new ArgumentException("No existe ese Tema");
            }
        }


         private void ThrowErrorIfItsInvalid(Tema a) 
        {
            int existeElTema = repository.GetAll().Where(x=>x.Nombre==a.Nombre).ToList().Count;
            if (existeElTema>0)
            {
                throw new ArgumentException("Ya existe Tema con ese Nombre");
            }
        }

        public Tema GetByString(string stringg)
        {
            try{
                return repository.GetByString(stringg);
            }catch(Exception){
                throw new ArgumentException("No existe ese Tema");
            }
        }
    }
}