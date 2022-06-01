using Moq;
using System.Collections.Generic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMMRequest.Domain;
using IMMRequest.DataAccess.Interface;
using IMMRequest.BusinessLogic.Interface;
using Microsoft.EntityFrameworkCore;
using IMMRequest.DataAccess;

namespace IMMRequest.BusinessLogic.Tests
{
    [TestClass]
    public class SessionLogicTest
    {
        //dotnet test /p:CollectCoverage=true
        
        [ExpectedException(typeof(ArgumentException), "Datos invalido")]
        [TestMethod]
        public void LoginMailInvalidoTest()
        {
            Administrador admin = new Administrador(){
                Email="diego@d.com",
                Contrasena="diego"
            };
            
            var mock = new Mock<IRepository<AdminSession>>(MockBehavior.Strict);
            var mockAdmin = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mockAdmin.Setup(m => m.Get(1));
            mockAdmin.Setup(m => m.GetByString("s")).Returns(new Administrador());
            var SolicitudLogic = new SesionLogic(mockAdmin.Object,mock.Object);
            var v = SolicitudLogic.Login("s","dsa");
            mock.VerifyAll();
        }
        
        [TestMethod]
        public void LoginMailValidoAdminLogueadoTest()
        {
            Administrador admin = new Administrador(){
                Nombre = "Diego",
                Email="diego@d.com",
                Contrasena="diego"
            };

            AdminSession adminS= new AdminSession(){
                admin=admin
            };
            
            var mock = new Mock<IRepository<AdminSession>>(MockBehavior.Strict);
            var mockAdmin = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mockAdmin.Setup(m => m.Get(1));
            mockAdmin.Setup(m => m.GetByString(admin.Email)).Returns(admin);
            mock.Setup(m => m.GetAll()).Returns(() => new List<AdminSession>(){adminS});
            var SolicitudLogic = new SesionLogic(mockAdmin.Object,mock.Object);
            var v = SolicitudLogic.Login(admin.Email,admin.Contrasena);
            mock.VerifyAll();
        }

        //[TestMethod]
        public void LoginMailValidoAdminNoLogueadoTest()
        {
            Administrador admin = new Administrador(){
                Nombre = "Diego",
                Email="diego@d.com",
                Contrasena="diego"
            };
            AdminSession adminS2= new AdminSession(){
                admin=admin,
                Id=2
            };

            Administrador admin2 = new Administrador(){
                Nombre = "Diego",
                Email="diego2@d.com",
                Contrasena="diego"
            };
            int id =1;
            AdminSession adminS= new AdminSession(){
                admin=admin2,
                Id=id
            };


            
            var mock = new Mock<IRepository<AdminSession>>(MockBehavior.Strict);
            var mockAdmin = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m=>m.Add(adminS2));
            mock.Setup(m=>m.Add(adminS));
            mockAdmin.Setup(m => m.Get(id)).Returns(admin2);
            mockAdmin.Setup(m => m.GetByString(admin.Email)).Returns(admin);
            mock.Setup(m => m.GetAll()).Returns(() => new List<AdminSession>(){adminS});
            var SolicitudLogic = new SesionLogic(mockAdmin.Object,mock.Object);
            //var v = SolicitudLogic.Login(admin.Email,admin.Contrasena);
            mock.VerifyAll();
        }

        [TestMethod]
        public void AdminLogueadoTest()
        {
            Administrador admin = new Administrador(){
                Nombre = "Diego",
                Email="diego@d.com",
                Contrasena="diego"
            };
            int token = 1;
            AdminSession adminS= new AdminSession(){
                admin=admin,
                Token = token
            };
            
            var mock = new Mock<IRepository<AdminSession>>(MockBehavior.Strict);
            var mockAdmin = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<AdminSession>(){adminS});
            var SolicitudLogic = new SesionLogic(mockAdmin.Object,mock.Object);
            var v = SolicitudLogic.estaLogueado(1);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetByEmailValidoTest()
        {
            Administrador admin = new Administrador(){
                Nombre = "Diego",
                Email="diego@d.com",
                Contrasena="diego"
            };
            int token = 1;
            AdminSession adminS= new AdminSession(){
                admin=admin,
                Token = token
            };
            
            var mock = new Mock<IRepository<AdminSession>>(MockBehavior.Strict);
            var mockAdmin = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<AdminSession>(){adminS});
            var SolicitudLogic = new SesionLogic(mockAdmin.Object,mock.Object);
            var v = SolicitudLogic.GetByEmail(admin.Email);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "Datos invalido")]
        [TestMethod]
        public void GetByEmailInValidoTest()
        {
            Administrador admin = new Administrador(){
                Nombre = "Diego",
                Email="diego@d.com",
                Contrasena="diego"
            };
            int token = 1;
            AdminSession adminS= new AdminSession(){
                admin=admin,
                Token = token
            };
            
            var mock = new Mock<IRepository<AdminSession>>(MockBehavior.Strict);
            var mockAdmin = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<AdminSession>(){adminS});
            var SolicitudLogic = new SesionLogic(mockAdmin.Object,mock.Object);
            var v = SolicitudLogic.GetByEmail("test");
            mock.VerifyAll();
        }

        
        
    }
}