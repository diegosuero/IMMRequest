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
    public class AreaLogicTest
    {
        //dotnet test /p:CollectCoverage=true

        [ExpectedException(typeof(ArgumentException), "Ya existe Area con ese Nombre")]
        [TestMethod]
        public void CrearAreaInValidaTest()
        {
            Area a = new Area("test");
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<Area>(){new Area("test"){}});
            mock.Setup(m => m.Add(It.IsAny<Area>()));
            mock.Setup(m => m.Save());
            var AreaLogic = new AreaLogic(mock.Object);
            var result = AreaLogic.Create(a);
            mock.VerifyAll();
            Assert.AreEqual(a.Nombre, result.Nombre);
        }

        [TestMethod]
        public void CrearAreaValidaTest()
        {
            Area a = new Area("test");
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(() => new List<Area>());
            mock.Setup(m => m.Add(It.IsAny<Area>()));
            mock.Setup(m => m.Save());
            var AreaLogic = new AreaLogic(mock.Object);
            var result = AreaLogic.Create(a);
            mock.VerifyAll();
            Assert.AreEqual(a.Nombre, result.Nombre);
        }

         [TestMethod]
        public void GetAllAreaCaseEmpty()
        {
            var lista = new List<Area>();
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(lista);
            var AreaLogic = new AreaLogic(mock.Object);
            var res = AreaLogic.GetAll();
            mock.VerifyAll();
            Assert.AreEqual(lista, res);
        }

        [TestMethod]
        public void GetAreaExist()
        {
             Area area = new Area("test");
             area.Id = 1;
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(area.Id)).Returns(area);
            var AreaLogic = new AreaLogic(mock.Object);
            var res = AreaLogic.Get(1);
            mock.VerifyAll();
            Assert.AreEqual(res.Id, area.Id);
        }

        
        [ExpectedException(typeof(ArgumentException), "No existe ese Area")]
        [TestMethod]
        public void GetAreaDontExist()
        {
            int id =15;
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            var AreaLogic = new AreaLogic(mock.Object);
            var res =AreaLogic.Get(id);
            mock.VerifyAll();
        }

        
        [ExpectedException(typeof(ArgumentException), "No existe ese Area")]
        [TestMethod]
        public void RemoveAreaDontExist(){
            int id=15;
            Area area = new Area("test");
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Throws<ArgumentException>();
            mock.Setup(m => m.Remove(area)).Throws<ArgumentException>();
            var AreaLogic = new AreaLogic(mock.Object);
            AreaLogic.Remove(id);
            mock.VerifyAll();

        }

        [TestMethod]
        public void RemoveAreaExist(){
            
            int id=15;
            Area area = new Area("test");
            area.Id=id;
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(area.Id)).Returns(area);
            mock.Setup(m => m.Remove(area));
            mock.Setup(m => m.Save());
            var AreaLogic = new AreaLogic(mock.Object);
            AreaLogic.Remove(id);
            mock.VerifyAll();

        }

        [ExpectedException(typeof(ArgumentException), "Ya existe Area con ese Nombre")]
        [TestMethod]
        public void UpdateAreaExistInValida(){
            
            int id=15;
            Area area = new Area("test");
            area.Id=id;
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.Get(id)).Returns(area);
            mock.Setup(m => m.GetByString(area.Nombre)).Returns(area);
            mock.Setup(m => m.GetAll()).Returns(new List<Area>(){area});
            mock.Setup(m => m.Remove(area));
            mock.Setup(m => m.Save());
            var AreaLogic = new AreaLogic(mock.Object);
            AreaLogic.Create(area);
            AreaLogic.Update(id,area);
            mock.VerifyAll();

        }

        [TestMethod]
        public void GetByStringAreaExist()
        {
             Area area = new Area("test");
             area.Id = 1;
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString(area.Nombre)).Returns(area);
            var AreaLogic = new AreaLogic(mock.Object);
            var res = AreaLogic.GetByString(area.Nombre);
            mock.VerifyAll();
            Assert.AreEqual(res.Id, area.Id);
        }

        
        [ExpectedException(typeof(ArgumentException), "No existe ese Area")]
        [TestMethod]
        public void GetByStringAreaDontExist()
        {
            var mock = new Mock<IRepository<Area>>(MockBehavior.Strict);
            mock.Setup(m => m.GetByString("d")).Throws<ArgumentException>();
            var AreaLogic = new AreaLogic(mock.Object);
            var res =AreaLogic.GetByString("d");
            mock.VerifyAll();
        }


        
    }
}