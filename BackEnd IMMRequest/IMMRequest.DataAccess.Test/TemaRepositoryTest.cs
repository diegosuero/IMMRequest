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
    public class TemaRepositoryTest
    {
        //dotnet test /p:CollectCoverage=true

        [TestMethod]
        public void AddTema()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                manager.Add(t);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 1);
                context.Set<Tema>().Remove(t);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void RemoveTemaExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                context.Set<Tema>().Add(t);
                context.SaveChanges();
                manager.Remove(t);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Tema no existe")]
        [TestMethod]
        public void RemoveTemaNotExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                manager.Remove(t);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);
            }
        }

        [TestMethod]
        public void UpdateTemaExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                context.Set<Tema>().Add(t);
                context.SaveChanges();
                t.Nombre="tema2";
                manager.Update(t);
                manager.Save();
                Assert.AreEqual(manager.Get(id).Nombre, "tema2");
                context.Set<Tema>().Remove(t);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Tema no existe")]
        [TestMethod]
        public void UpdateTemaNotExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                manager.Update(t);
                manager.Save();
            }
        }

        [TestMethod]
        public void GetAll()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

           int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                manager.Add(t);
                manager.Save();
                List<Tema> res= manager.GetAll().ToList();
                Assert.AreEqual(res.Count, 1);
                context.Set<Tema>().Remove(t);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetByIdExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                manager.Add(t);
                manager.Save();
                Tema res = manager.Get(id);
                Assert.AreEqual(res, t);
                context.Set<Tema>().Remove(t);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Tema no existe")]
        [TestMethod]
        public void GetByIdNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                Tema res = manager.Get(id);
                Assert.AreEqual(res, t);
            }
        }

        [TestMethod]
        public void GetByStringExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;
            
            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                manager.Add(t);
                manager.Save();
                Tema res = manager.GetByString(t.Nombre);
                Assert.AreEqual(res, t);
                context.Set<Tema>().Remove(t);
                context.SaveChanges();
            }
        }
        
        [ExpectedException(typeof(KeyNotFoundException), "El Tema no existe")]
        [TestMethod]
        public void GetByStringNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;
            
            int id =1;
            Tema t = new Tema(){
                Id=id,
                Nombre= "tema"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TemaRepository(context);
                Tema res = manager.GetByString(t.Nombre);
                Assert.AreEqual(res, t);
            }
        }



    }
}