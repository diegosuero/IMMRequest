using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using IMMRequest.DataAccess;
using IMMRequest.Domain;

namespace IMMRequest.DataAccess.Test
{
    [TestClass]
    public class AreaRepositoryTest
    {

        
    //dotnet test /p:CollectCoverage=true

        [TestMethod]
        public void AddArea()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;
            List<Tema> list= new List<Tema>(){};
            int id =1;
           Area a = new Area("area"){
               Id= id,
               Temas= list
               
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AreaRepository(context);
                manager.Add(a);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 1);
                context.Set<Area>().Remove(a);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void RemoveAreaExist()
        {
           var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;
            List<Tema> list= new List<Tema>(){};
           Area a = new Area("area"){
               Id= id,
               Temas= list
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AreaRepository(context);
                context.Set<Area>().Add(a);
                context.SaveChanges();
                manager.Remove(a);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);

            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El area no existe")]
        [TestMethod]
        public void RemoveAreaNotExist()
        {
           var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;
           Area a = new Area("area"){
               Id= id,
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AreaRepository(context);
                manager.Remove(a);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);

            }
        }

        [TestMethod]
        public void UpdateAreaExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

           
            int id =1;
           Area a = new Area("area"){
               Id= id,
           };
            using (var context = new IMMRequestContext(options))
            {
              context.Set<Area>().Add(a);
                context.SaveChanges();
                var manager = new AreaRepository(context);
                a.Nombre = "area2";
                manager.Update(a);
                manager.Save();
                Assert.AreEqual(manager.Get(id).Nombre, "area2");
                context.Set<Area>().Remove(a);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El area no existe")]
        [TestMethod]
        public void UpdateAreaNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

           
            int id =1;
           Area a = new Area("area"){
               Id= id,
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AreaRepository(context);
                manager.Update(a);
                manager.Save();
                Assert.AreEqual(manager.Get(id).Nombre, "area2");
            }
        }

         [TestMethod]
        public void GetAll()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase3")
            .Options;

            int id =1;
           Area a = new Area("area"){
               Id= id,
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AreaRepository(context);
                manager.Add(a);
                manager.Save();
                List<Area> list = manager.GetAll().ToList();
                Assert.AreEqual(list.Count, 1);
                context.Set<Area>().Remove(a);
                context.SaveChanges();
            }
           
        }

        [TestMethod]
        public void GetByIdExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

            int id =22323;

            Area a = new Area("area"){
               Id= id,
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AreaRepository(context);
                manager.Add(a);
                manager.Save();
                Area res = manager.Get(id);
                Assert.AreEqual(res, a);
                context.Set<Area>().Remove(a);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El area no existe")]
        [TestMethod]
        public void GetByIdNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;


            using (var context = new IMMRequestContext(options))
            {
                var manager = new AreaRepository(context);
                Area res = manager.Get(33);
                Assert.AreEqual(res, null);

            }
        }

        [TestMethod]
        public void GetByStringExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

            int id =22323;

            Area a = new Area("area"){
               Id= id,
           };

            using (var context = new IMMRequestContext(options))
            {
                context.Set<Area>().Add(a);
                context.SaveChanges();
                var manager = new AreaRepository(context);
                Area res = manager.GetByString(a.Nombre);
                Assert.AreEqual(res, a);
                context.Set<Area>().Remove(a);
                context.SaveChanges();
            }
        }


        [ExpectedException(typeof(KeyNotFoundException), "El area no existe")]
        [TestMethod]
        public void GetByStringNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

            using (var context = new IMMRequestContext(options))
            {
                var manager = new AreaRepository(context);
                Area res = manager.GetByString("string");
                Assert.AreEqual(res, null);

            }
        }
       

        
    }
}