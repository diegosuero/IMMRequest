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
    public class TipoDeTemaLogicTest
    {
     //dotnet test /p:CollectCoverage=true
        [TestMethod]
        public void CrearTipoValidoTest()
        {
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema"
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(t));
            mock.Setup(m => m.Save());
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            var v = TipoDeTemaLogic.Create(t);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetTipoValidoTest()
        {
            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(t);
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            var v = TipoDeTemaLogic.Get(id);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Tipo")]
        [TestMethod]
        public void GetTipoInValidoTest()
        {
            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            var v = TipoDeTemaLogic.Get(id);
            mock.VerifyAll();
        }
        
        [TestMethod]
        public void GetAllTest()
        {
            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<TipoDeTema>());
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            var v = TipoDeTemaLogic.GetAll();
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Tipo")]
        [TestMethod]
        public void RemoveNotExistTest()
        {

            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            mock.Setup(m => m.Remove(t));
            mock.Setup(m => m.Save());
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            TipoDeTemaLogic.Remove(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void RemoveExistTest()
        {

            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(t);
            mock.Setup(m => m.Remove(t));
            mock.Setup(m => m.Save());
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            TipoDeTemaLogic.Remove(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateExistTest()
        {

            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(t);
            mock.Setup(m => m.Update(t));
            mock.Setup(m => m.Save());
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            TipoDeTemaLogic.Update(id,t);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Tipo")]
        [TestMethod]
        public void UpdateNotExistTest()
        {

            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            mock.Setup(m => m.Save());
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            TipoDeTemaLogic.Update(id,t);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Tipo")]
        [TestMethod]
        public void GetByStringNotExistTest()
        {

            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(t.nombre)).Throws<ArgumentException>();
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            TipoDeTemaLogic.GetByString(t.nombre);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetByStringExistTest()
        {

            int id = 1;
            TipoDeTema t = new TipoDeTema(){
                nombre="Tema",
                ID=id
            };
            
            var mock = new Mock<IRepository<TipoDeTema>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(t.nombre)).Returns(t);
            var TipoDeTemaLogic = new TipoDeTemaLogic(mock.Object);
            TipoDeTemaLogic.GetByString(t.nombre);
            mock.VerifyAll();
        }   
    }
}