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
    public class CampoAdicionalFechaLogicTest
    {
        //dotnet test /p:CollectCoverage=true
        [TestMethod]
        public void CrearCampoValidoTest()
        {
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo"
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(c));
            mock.Setup(m => m.Save());
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            var v = CampoAdicionalFechaLogic.Create(c);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetValidoTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            var v = CampoAdicionalFechaLogic.Get(id);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void GetInValidoTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            var v = CampoAdicionalFechaLogic.Get(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetAllTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<CampoAdicionalFecha>());
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            var v = CampoAdicionalFechaLogic.GetAll();
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetByStringExistTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(c.Nombre)).Returns(c);
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            var v = CampoAdicionalFechaLogic.GetByString(c.Nombre);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void GetByStringNotExistTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(c.Nombre)).Throws<ArgumentException>();
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            var v = CampoAdicionalFechaLogic.GetByString(c.Nombre);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void RemoveNotExistTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            CampoAdicionalFechaLogic.Remove(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void RemoveExistTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            mock.Setup(m => m.Remove(c));
            mock.Setup(m => m.Save());
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            CampoAdicionalFechaLogic.Remove(id);
            mock.VerifyAll();
        }
        
                [ExpectedException(typeof(ArgumentException), "No existe ese Campo")]
        [TestMethod]
        public void UpdateNotExistTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            CampoAdicionalFechaLogic.Update(id,c);
            mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateExistTest()
        {
            int id = 1;
            CampoAdicionalFecha c = new CampoAdicionalFecha(){
                Nombre="campo",
                Id=id
            };
            
            var mock = new Mock<IRepository<CampoAdicionalFecha>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(c);
            mock.Setup(m => m.Update(c));
            mock.Setup(m => m.Save());
            var CampoAdicionalFechaLogic = new CampoAdicionalFechaLogic(mock.Object);
            CampoAdicionalFechaLogic.Update(id,c);
            mock.VerifyAll();
        }
    }
}