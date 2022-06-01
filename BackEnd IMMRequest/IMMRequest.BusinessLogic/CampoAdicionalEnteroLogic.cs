using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    

    public class CampoAdicionalEnteroLogic : ILogic<CampoAdicionalEntero>
    {
        private IRepository<CampoAdicionalEntero> repository;


        public CampoAdicionalEnteroLogic(IRepository<CampoAdicionalEntero> campoEntero){
            this.repository = campoEntero;

        }

        public CampoAdicionalEntero Create(CampoAdicionalEntero entity)
        {
                repository.Add((CampoAdicionalEntero)entity);
                repository.Save();
                return entity;
        }

        public CampoAdicionalEntero Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }

        public IEnumerable<CampoAdicionalEntero> GetAll()
        {
            return repository.GetAll();
        }

        public CampoAdicionalEntero GetByString(string stringg)
        {
            try{
                return repository.GetByString(stringg);
            }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }

        public void Remove(int id)
        {
            try{
                CampoAdicionalEntero c = Get(id);
                repository.Remove(c);
                repository.Save();
            }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }

        public CampoAdicionalEntero Update(int id, CampoAdicionalEntero entity)
        {
             try{
                CampoAdicionalEntero c = repository.Get(id);
                entity.Id=c.Id;
                repository.Update(entity);
                repository.Save();
                return entity;
            }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }
    }
}