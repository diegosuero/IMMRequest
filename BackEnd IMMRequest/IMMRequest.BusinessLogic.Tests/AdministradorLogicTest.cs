using Moq;
using System.Collections.Generic;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMMRequest.Domain;
using IMMRequest.DataAccess.Interface;

namespace IMMRequest.BusinessLogic.Tests
{
   
   [TestClass]
    public class AdministradorLogicTest
    {
        [TestMethod]
        public void CrearAdministradorValidoTest()
        {
            Administrador administrador = new Administrador("Diego","diego@email.com","Password");
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<Administrador>());
            mock.Setup(m => m.Add(It.IsAny<Administrador>()));
            mock.Setup(m => m.Save());
            var AdministradorLogic = new AdministradorLogic(mock.Object);

            var result = AdministradorLogic.Create(administrador);

            mock.VerifyAll();
            Assert.AreEqual(administrador.Email, result.Email);
        }

        [ExpectedException(typeof(ArgumentException), "El Administrador es invalido")]
        [TestMethod]
        public void CrearAdministradorMailInvalidoTest()
        {
            Administrador administrador = new Administrador("Diego","diego@emailcom","Password");
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<Administrador>());
            mock.Setup(m => m.Add(It.IsAny<Administrador>()));
            mock.Setup(m => m.Save());
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var result = AdministradorLogic.Create(administrador);
            mock.VerifyAll();
            Assert.AreEqual(administrador.Email, result.Email);
        }

        
        [ExpectedException(typeof(ArgumentException), "El Email ya existe en otro Administrador")]
        [TestMethod]
        public void CrearAdministradorConOtroAdminMismoEmail()
        {
            Administrador administrador = new Administrador("Diego","diego@email.com","Password");
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<Administrador>(){new Administrador("Diego","diego@email.com","Password"){}});
            mock.Setup(m => m.Add(It.IsAny<Administrador>()));
            mock.Setup(m => m.Save());
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var result = AdministradorLogic.Create(administrador);
            mock.VerifyAll();
            Assert.AreEqual(administrador.Email, result.Email);
        }

        [TestMethod]
        public void GetAllAdministradoresCaseEmpty()
        {
            var lista = new List<Administrador>();
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(lista);
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var res = AdministradorLogic.GetAll();
            mock.VerifyAll();
            Assert.AreEqual(lista, res);
        }

        [TestMethod]
        public void GetAdminExist()
        {
             Administrador admin = new Administrador("Diego","diego@emailcom","Password");
             admin.Id = 1;
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(admin.Id)).Returns(admin);
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var res = AdministradorLogic.Get(admin.Id);
            mock.VerifyAll();
            Assert.AreEqual(res.Id, admin.Id);
        }

        
        
        [ExpectedException(typeof(ArgumentException), "No existe ese id")]
        [TestMethod]
        public void GetAdminDontExist()
        {
            int id =15;
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var res =AdministradorLogic.Get(id);
            mock.VerifyAll();
        }

        
        [ExpectedException(typeof(ArgumentException), "No existe ese id")]
        [TestMethod]
        public void RemoveAdminDontExist(){
            int id=15;
            Administrador admin = new Administrador();
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            mock.Setup(m => m.Remove(admin)).Throws<ArgumentException>();
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            AdministradorLogic.Remove(id);
            mock.VerifyAll();

        }


        [TestMethod]
        public void RemoveAdminExist(){
            
            int id=15;
            Administrador administrador = new Administrador("Diego","diego@email.com","Password");
            administrador.Id=id;
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<Administrador>());
            mock.Setup(m => m.Add(It.IsAny<Administrador>()));
            mock.Setup(m => m.Get(administrador.Id)).Returns(administrador);
            mock.Setup(m => m.Remove(administrador));
            mock.Setup(m => m.Save());
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var result = AdministradorLogic.Create(administrador);
            AdministradorLogic.Remove(id);
            mock.VerifyAll();

        }

                [TestMethod]
        public void UpdateAdminExistValido(){
            
            int id=15;
            Administrador administrador = new Administrador("Diego","diego@email.com","Password");
            administrador.Id=id;
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<Administrador>());
            mock.Setup(m => m.Add(It.IsAny<Administrador>()));
            mock.Setup(m => m.Update(It.IsAny<Administrador>()));
            mock.Setup(m => m.Get(administrador.Id)).Returns(administrador);
            mock.Setup(m => m.Save());
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var result = AdministradorLogic.Create(administrador);
            AdministradorLogic.Update(id,administrador);
            mock.VerifyAll();

    }
        [ExpectedException(typeof(ArgumentException), "El Administrador es invalido")]
        [TestMethod]
        public void UpdateAdminExistInValido(){
            
            int id=15;
            Administrador administrador = new Administrador("Diego","diego@email.com","Password");
            administrador.Id=id;
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<Administrador>());
            mock.Setup(m => m.Add(It.IsAny<Administrador>()));
            mock.Setup(m => m.Update(It.IsAny<Administrador>()));
            mock.Setup(m => m.Get(administrador.Id)).Returns(administrador);
            mock.Setup(m => m.Save());
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var result = AdministradorLogic.Create(administrador);
            administrador.Email="invalido";
            AdministradorLogic.Update(id,administrador);
            mock.VerifyAll();
    }

        [TestMethod]
        public void GetByStringAdminExist()
        {
             Administrador admin = new Administrador("Diego","diego@emailcom","Password");
             admin.Id = 1;
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<Administrador>(){admin});
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var res = AdministradorLogic.GetByString(admin.Email);
            mock.VerifyAll();
            Assert.AreEqual(res.Id, admin.Id);
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Administrador")]
        [TestMethod]
        public void GetByStringAdminNotExist()
        {
             Administrador admin = new Administrador("Diego","diego@emailcom","Password");
             admin.Id = 1;
            var mock = new Mock<IRepository<Administrador>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<Administrador>(){});
            var AdministradorLogic = new AdministradorLogic(mock.Object);
            var res = AdministradorLogic.GetByString(admin.Email);
            mock.VerifyAll();
            Assert.AreEqual(res.Id, admin.Id);
        }
    
}
}