using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    

    public class CampoAdicionalTextoLogic : ILogic<CampoAicionalTexto>
    {
        private IRepository<CampoAicionalTexto> repository;


        public CampoAdicionalTextoLogic(IRepository<CampoAicionalTexto> campoEntero){
            this.repository = campoEntero;

        }

        public CampoAicionalTexto Create(CampoAicionalTexto entity)
        {
                repository.Add((CampoAicionalTexto)entity);
                repository.Save();
                return entity;
        }

        public CampoAicionalTexto Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }

        public IEnumerable<CampoAicionalTexto> GetAll()
        {
            return repository.GetAll();
        }

        public CampoAicionalTexto GetByString(string stringg)
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
                CampoAicionalTexto c = Get(id);
                repository.Remove(c);
                repository.Save();
             }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }     
        }

        public CampoAicionalTexto Update(int id, CampoAicionalTexto entity)
        {
            try{
                CampoAicionalTexto c = repository.Get(id);
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