using IMMRequest.Domain;
using System;
using System.Collections.Generic;
namespace IMMRequest.WebApi.Models
{
    public class AdminModel : Model<Administrador, AdminModel>
    {
        public AdminModel()
        {
        }

        public AdminModel(Administrador administrador)
        {
            SetModel(administrador);
        }

        public string Nombre { get; set; }
        public string Contrrasena { get; set; }
        public string Email { get; set; }

        public override Administrador ToEntity() => new Administrador()
        {
            Nombre = this.Nombre,
            Email = this.Email,
            Contrasena = this.Contrrasena,

        };

        protected override AdminModel SetModel(Administrador admin)
        {
            Nombre = admin.Nombre;
            Email = admin.Email;
            Contrrasena = admin.Contrasena;
            return this;
        }
    }
}