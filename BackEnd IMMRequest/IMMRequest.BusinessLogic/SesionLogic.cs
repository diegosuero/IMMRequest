using System;
using System.Collections.Generic;
using IMMRequest.BusinessLogic.Interface;
using IMMRequest.DataAccess.Interface;
using IMMRequest.Domain;
using System.Linq;

namespace IMMRequest.BusinessLogic
{
    


    public class SesionLogic : ISession<AdminSession>
    {
        private IRepository<Administrador> repo;
        private IRepository<AdminSession> repoAdmins;

        public SesionLogic(IRepository<Administrador> repo, IRepository<AdminSession> repoAdmins)
        {
            this.repo = repo;
            this.repoAdmins = repoAdmins;
        }

        public bool estaLogueado(int token)
        {
            return (repoAdmins.GetAll().Where(x=>x.Token==token).Count())>0;
        }

        public IEnumerable<AdminSession> GetAll()
        {
            return repoAdmins.GetAll();
        }

        public int Login(string email, string password)
        {
            
            var random = new Random();
            Administrador admin = repo.GetByString(email);
            
            if(admin!=null && admin.Contrasena==password){
                    int token = random.Next();
                    AdminSession adminSession = new AdminSession(){
                        admin= admin,
                        Token = token
                    };
                repoAdmins.Add(adminSession);
                repoAdmins.Save();
                return token;
                
            }
            throw new ArgumentException("Datos invalido");
        }

        public Boolean hayLogin(string email){
            return (repoAdmins.GetAll().Where(x=>x.admin.Email==email).Count())>0;
        }
        public AdminSession GetByEmail(string email){
            try{
                List <AdminSession> list = repoAdmins.GetAll().ToList();
                return list.First(x => x.admin.Email == email);
            }catch(Exception){
                throw new ArgumentException("Datos invalido");
            }

        }
    }
}