using IMMRequest.Domain;
using System;
using System.Collections.Generic;

namespace IMMRequest.WebApi.Models
{
    public class LoginModel :Model<AdminSession, LoginModel>
    {
        public LoginModel()
        {
        }

        public LoginModel(AdminSession adminSession)
        {
            SetModel(adminSession);
        }
        public String email {get;set;}
        public String password{get;set;}


        public override AdminSession ToEntity() => new AdminSession()
        {
                admin = new Administrador(){
                    Email=this.email,
                    Contrasena = this.password
                }        
            //throw new NotImplementedException();
        };

        protected override LoginModel SetModel(AdminSession entity)
        {
            email = entity.admin.Email;
            password= entity.admin.Contrasena;
            return this;
        }
    }
}