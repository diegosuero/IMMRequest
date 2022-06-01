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
    public class CampoAdicionalTextoLogicTest
    {
        //dotnet test /p:CollectCoverage=true
        [TestMethod]
        public void CrearCampoValidoTest()
        {
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo"
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(c));
            mock.Setup(m => m.Save());
            var CampoAicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            var v = CampoAicionalTextoLogic.Create(c);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetValidoTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            var v = CampoAdicionalTextoLogic.Get(id);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void GetInValidoTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            var v = CampoAdicionalTextoLogic.Get(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetAllTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<CampoAicionalTexto>());
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            var v = CampoAdicionalTextoLogic.GetAll();
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetByStringExistTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(c.Nombre)).Returns(c);
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            var v = CampoAdicionalTextoLogic.GetByString(c.Nombre);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void GetByStringNotExistTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(c.Nombre)).Throws<ArgumentException>();
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            var v = CampoAdicionalTextoLogic.GetByString(c.Nombre);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void RemoveNotExistTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            CampoAdicionalTextoLogic.Remove(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void RemoveExistTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            mock.Setup(m => m.Remove(c));
            mock.Setup(m => m.Save());
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            CampoAdicionalTextoLogic.Remove(id);
            mock.VerifyAll();
        }
        
        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void UpdateNotExistTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            CampoAdicionalTextoLogic.Update(id,c);
            mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateExistTest()
        {
            int id = 1;
            CampoAicionalTexto c = new CampoAicionalTexto(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAicionalTexto>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            mock.Setup(m => m.Update(c));
            mock.Setup(m => m.Save());
            var CampoAdicionalTextoLogic = new CampoAdicionalTextoLogic(mock.Object);
            CampoAdicionalTextoLogic.Update(id,c);
            mock.VerifyAll();
        }
    }
}