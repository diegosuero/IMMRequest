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
    public class CampoAdicionalEnteroLogicTest
    {
        //dotnet test /p:CollectCoverage=true
        [TestMethod]
        public void CrearCampoValidoTest()
        {
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo"
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(c));
            mock.Setup(m => m.Save());
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            var v = CampoAdicionalEnteroLogic.Create(c);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetValidoTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            var v = CampoAdicionalEnteroLogic.Get(id);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void GetInValidoTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            var v = CampoAdicionalEnteroLogic.Get(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetAllTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<CampoAdicionalEntero>());
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            var v = CampoAdicionalEnteroLogic.GetAll();
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetByStringExistTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(c.Nombre)).Returns(c);
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            var v = CampoAdicionalEnteroLogic.GetByString(c.Nombre);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void GetByStringNotExistTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(c.Nombre)).Throws<ArgumentException>();
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            var v = CampoAdicionalEnteroLogic.GetByString(c.Nombre);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void RemoveNotExistTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            CampoAdicionalEnteroLogic.Remove(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void RemoveExistTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            mock.Setup(m => m.Remove(c));
            mock.Setup(m => m.Save());
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            CampoAdicionalEnteroLogic.Remove(id);
            mock.VerifyAll();
        }
        
                [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void UpdateNotExistTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            CampoAdicionalEnteroLogic.Update(id,c);
            mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateExistTest()
        {
            int id = 1;
            CampoAdicionalEntero c = new CampoAdicionalEntero(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalEntero>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            mock.Setup(m => m.Update(c));
            mock.Setup(m => m.Save());
            var CampoAdicionalEnteroLogic = new CampoAdicionalEnteroLogic(mock.Object);
            CampoAdicionalEnteroLogic.Update(id,c);
            mock.VerifyAll();
        }
    }
}