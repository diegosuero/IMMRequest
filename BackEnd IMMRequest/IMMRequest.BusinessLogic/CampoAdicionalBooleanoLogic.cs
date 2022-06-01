using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    

    public class CampoAdicionalBooleanoLogic : ILogic<CampoAdicionalBooleano>
    {
        private IRepository<CampoAdicionalBooleano> repository;


        public CampoAdicionalBooleanoLogic(IRepository<CampoAdicionalBooleano> campoEntero){
            this.repository = campoEntero;

        }

        public CampoAdicionalBooleano Create(CampoAdicionalBooleano entity)
        {
                repository.Add((CampoAdicionalBooleano)entity);
                repository.Save();
                return entity;
        }

        public CampoAdicionalBooleano Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }

        public IEnumerable<CampoAdicionalBooleano> GetAll()
        {
            return repository.GetAll();
        }

        public CampoAdicionalBooleano GetByString(string stringg)
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
                CampoAdicionalBooleano c = Get(id);
                repository.Remove(c);
                repository.Save();
            }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }

        public CampoAdicionalBooleano Update(int id, CampoAdicionalBooleano entity)
        {
             try{
                CampoAdicionalBooleano c = repository.Get(id);
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