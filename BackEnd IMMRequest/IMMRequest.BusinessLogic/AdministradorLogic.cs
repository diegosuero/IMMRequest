using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    public class AdministradorLogic : ILogic<Administrador>
    {
        private IRepository<Administrador> repository;

        public AdministradorLogic(IRepository<Administrador> repository)
        {
            this.repository = repository;
        }

        public Administrador Create(Administrador administrador)
        {
            
                ThrowErrorIfItsInvalid(administrador);
                repository.Add(administrador);
                repository.Save();
                return administrador;
        }

        public Administrador Get(int id)
        {
            try{
                return repository.Get(id);
            }catch(Exception){
                throw new ArgumentException("No existe ese id");
            }
            
        }

        public IEnumerable<Administrador> GetAll()
        {
            
           return repository.GetAll();
        }

        public void Remove(int id)
        {
            try{
                Administrador admin = Get(id);
                repository.Remove(admin);
                repository.Save();
            }catch(Exception){
                throw new ArgumentException("No existe ese id");
            }
        }

        public Administrador Update(int id, Administrador entity)
        {
            Administrador admin = repository.Get(id);
            entity.Id=admin.Id;
            //ThrowErrorIfItsInvalid(entity);
            ExisteEmailEnOtroAdmin(entity);
            admin.Update(entity);
            repository.Update(admin);
            return entity;
        }

        private void ThrowErrorIfItsInvalid(Administrador administrador) 
        {
            if (!administrador.esValido()) 
            {
                throw new ArgumentException("El Administrador es invalido");
            }
            int existeElAdmin = repository.GetAll().Where(x=>x.Email==administrador.Email).ToList().Count;
            if (existeElAdmin>0)
            {
                throw new ArgumentException("El Email ya existe en otro Administrador");
            }
        }

        private void ExisteEmailEnOtroAdmin(Administrador administrador){
            if(!administrador.esValido()){
                throw new ArgumentException("El Administrador es invalido");
            }
            int existeElAdmin = repository.GetAll().Where(x=>x.Email==administrador.Email&&x.Id != administrador.Id).ToList().Count;
            if (existeElAdmin>0)
            {
                throw new ArgumentException("El Email ya existe en otro Administrador");
            }
        }

        public Administrador GetByString(string stringg)
        {
            try{
                return repository.GetAll().First(x=>x.Email==stringg);
             }catch(Exception){
                throw new ArgumentException("No existe ese Administrador");
            }
        }
    }
}