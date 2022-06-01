using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    public class TipoDeTemaLogic : ILogic<TipoDeTema>
    {
        private IRepository<TipoDeTema> repository;

        public TipoDeTemaLogic(IRepository<TipoDeTema> repo)
        {
            this.repository = repo;
        }

        public TipoDeTema Create(TipoDeTema entity)
        {
            repository.Add(entity);
            repository.Save();
            return entity;
        }

        public TipoDeTema Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception){
                throw new ArgumentException("No existe ese Tipo");
            }
        }

        public IEnumerable<TipoDeTema> GetAll()
        {
            return repository.GetAll();
        }

        public TipoDeTema GetByString(string stringg)
        {
            try{
                return repository.GetByString(stringg);
            }catch(Exception){
                throw new ArgumentException("No existe ese Tipo");
            }
        }

        public void Remove(int id)
        {
            TipoDeTema tipo = Get(id);
            repository.Remove(tipo);
            repository.Save();
        }

        public TipoDeTema Update(int id, TipoDeTema entity)
        {
            TipoDeTema tipo = Get(id);
            entity.ID=tipo.ID;
            repository.Update(entity);
            repository.Save();
            return entity;
        }
    }
}