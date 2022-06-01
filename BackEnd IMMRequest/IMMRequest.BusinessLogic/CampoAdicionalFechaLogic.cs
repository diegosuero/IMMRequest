using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    

    public class CampoAdicionalFechaLogic : ILogic<CampoAdicionalFecha>
    {
        private IRepository<CampoAdicionalFecha> repository;


        public CampoAdicionalFechaLogic(IRepository<CampoAdicionalFecha> campoEntero){
            this.repository = campoEntero;

        }

        public CampoAdicionalFecha Create(CampoAdicionalFecha entity)
        {
                repository.Add((CampoAdicionalFecha)entity);
                repository.Save();
                return entity;
        }

        public CampoAdicionalFecha Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }

        public System.Collections.Generic.IEnumerable<CampoAdicionalFecha> GetAll()
        {
            return repository.GetAll();
        }

        public CampoAdicionalFecha GetByString(string stringg)
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
                CampoAdicionalFecha c = Get(id);
                repository.Remove(c);
                repository.Save();
             }catch(Exception){
                throw new ArgumentException("No existe ese Campo");
            }
        }

        public CampoAdicionalFecha Update(int id, CampoAdicionalFecha entity)
        {
             try{
                CampoAdicionalFecha c = repository.Get(id);
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