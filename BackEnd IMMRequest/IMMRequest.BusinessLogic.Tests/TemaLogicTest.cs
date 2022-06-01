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
    public class TemaLogicTest
    {
        //dotnet test /p:CollectCoverage=true
        [TestMethod]
        public void CrearTemaValidoTest()
        {
            Tema t = new Tema(){
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<Tema>());
            mock.Setup(m => m.Add(t));
            mock.Setup(m => m.Save());
            var TemaLogic = new TemaLogic(mock.Object);
            var v = TemaLogic.Create(t);
            mock.VerifyAll();
        }
        [ExpectedException(typeof(ArgumentException), "Ya existe Tema con ese Nombre")]
        [TestMethod]
        public void CrearTemaInValidoTest()
        {
            Tema t = new Tema(){
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<Tema>(){t});
            mock.Setup(m => m.Add(t));
            mock.Setup(m => m.Save());
            var TemaLogic = new TemaLogic(mock.Object);
            var v = TemaLogic.Create(t);
            mock.VerifyAll();
        }

        [TestMethod]
        public void GetTemaValidoTest()
        {
            int id = 1;
            Tema t = new Tema(){
                Id=id,
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(t);
            var TemaLogic = new TemaLogic(mock.Object);
            var v = TemaLogic.Get(id);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Tema")]
        [TestMethod]
        public void GetTemaInValidoTest()
        {
            int id = 1;
            Tema t = new Tema(){
                Id=id,
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var TemaLogic = new TemaLogic(mock.Object);
            var v = TemaLogic.Get(id);
            mock.VerifyAll();
        }
        
        [TestMethod]
        public void GetAllTest()
        {
            Tema t = new Tema(){
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(new List<Tema>());
            var TemaLogic = new TemaLogic(mock.Object);
            var v = TemaLogic.GetAll();
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Tema")]
        [TestMethod]
        public void RemoveNotExistTest()
        {

            int id = 1;
            Tema t = new Tema(){
                Id=id,
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            mock.Setup(m => m.Remove(t));
            mock.Setup(m => m.Save());
            var TemaLogic = new TemaLogic(mock.Object);
            TemaLogic.Remove(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void RemoveExistTest()
        {

            int id = 1;
            Tema t = new Tema(){
                Id=id,
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(t);
            mock.Setup(m => m.Remove(t));
            mock.Setup(m => m.Save());
            var TemaLogic = new TemaLogic(mock.Object);
            TemaLogic.Remove(id);
            mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateExistTest()
        {

            int id = 1;
            Tema t = new Tema(){
                Id=id,
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(t));
            mock.Setup(m => m.Save());
            var TemaLogic = new TemaLogic(mock.Object);
            TemaLogic.Update(id,t);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Tema")]
        [TestMethod]
        public void UpdateNotExistTest()
        {

            int id = 1;
            Tema t = new Tema(){
                Id=id,
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.Update(t)).Throws<ArgumentException>();
            mock.Setup(m => m.Save());
            var TemaLogic = new TemaLogic(mock.Object);
            TemaLogic.Update(id,t);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "No existe ese Tema")]
        [TestMethod]
        public void GetByStringNotExistTest()
        {

            int id = 1;
            Tema t = new Tema(){
                Id=id,
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(t.Nombre)).Throws<ArgumentException>();
            var TemaLogic = new TemaLogic(mock.Object);
            TemaLogic.GetByString(t.Nombre);
            mock.VerifyAll();
        }

                [TestMethod]
        public void GetByStringExistTest()
        {

            int id = 1;
            Tema t = new Tema(){
                Id=id,
                Nombre="Tema"
            };
            
            var mock = new Mock<IRepository<Tema>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(t.Nombre)).Returns(t);
            var TemaLogic = new TemaLogic(mock.Object);
            TemaLogic.GetByString(t.Nombre);
            mock.VerifyAll();
        }
    }
    
}