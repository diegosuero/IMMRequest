using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    public class AreaLogic : ILogic<Area>
    {
        private IRepository<Area> repository;

        public AreaLogic(IRepository<Area> repo)
        {
            repository=repo;
        }

        public Area Create(Area entity)
        { 
            ThrowErrorIfItsInvalid(entity);
            repository.Add(entity);
            repository.Save();
           
           return entity;
        }

        public Area Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception){
                throw new ArgumentException("No existe ese Area");
            }
        }

        public IEnumerable<Area> GetAll()
        {
            return repository.GetAll();
        }

        public void Remove(int id)
        {
             try{
                Area area = Get(id);
                repository.Remove(area);
                repository.Save();
            }catch(Exception){
                throw new ArgumentException("No existe ese Area");
            }
        }

        public Area Update(int id, Area entity)
        {
            try{
                Area a = repository.Get(id);
                entity.Id=a.Id;
                ExisteNombreEnOtroArea(entity);
                repository.Update(entity);
                return entity;
            }catch(Exception){
                throw new ArgumentException("No existe ese Area");
            }
            
        }
/*
        public Area ggetByName(String name){
            try{
                return repository.GetByString(name);
            }catch(Exception){
                throw new ArgumentException("No existe ese Area");
            }
        }
*/
         private void ThrowErrorIfItsInvalid(Area a) 
        {
            int existeElArea = repository.GetAll().Where(x=>x.Nombre==a.Nombre).ToList().Count;
            if (existeElArea>0)
            {
                throw new ArgumentException("Ya existe Area con ese Nombre");
            }
        }

        public Area GetByString(String stringg)
        {
            try{
                return repository.GetByString(stringg);
            }catch(Exception){
                throw new ArgumentException("No existe ese Area");
            }
            
        }

        private void ExisteNombreEnOtroArea(Area area){
            int existeElArea = repository.GetAll().Where(x=>x.Nombre==area.Nombre&&x.Id != area.Id).ToList().Count;
            if (existeElArea>0)
            {
                throw new ArgumentException("El Nombre del Area ya existe en otro Area");
            }
        }
    }
}