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
    public class TipoRepositoryTest
    {

        //dotnet test /p:CollectCoverage=true

        [TestMethod]
        public void AddTipo()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;
            int id =1;

            TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };

            using (var context = new IMMRequestContext(options))
            {
                var manager = new TipoRepository(context);
                manager.Add(t);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 1);
                context.Set<TipoDeTema>().Remove(t);
                context.SaveChanges();
            }
        }


        [TestMethod]
        public void RemoveTipoExist()
        {
           var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };
            using (var context = new IMMRequestContext(options))
            {
                   var manager = new TipoRepository(context);
                context.Set<TipoDeTema>().Add(t);
                context.SaveChanges();
                manager.Remove(t);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);

            }
        }
        [ExpectedException(typeof(KeyNotFoundException), "El Tipo no existe")]
        [TestMethod]
        public void RemoveTipoNotExist()
        {
           var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new TipoRepository(context);
                manager.Remove(t);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);

            }
        }

        [TestMethod]
        public void UpdateTipoExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

            int id =1;
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };
            using (var context = new IMMRequestContext(options))
            {
                context.Set<TipoDeTema>().Add(t);
                context.SaveChanges();
                var manager = new TipoRepository(context);
                t.nombre="test2";
                manager.Update(t);
                manager.Save();
                Assert.AreEqual(manager.Get(id).nombre, "test2");
                context.Set<TipoDeTema>().Remove(t);
                context.SaveChanges();
            }
        }



        [ExpectedException(typeof(KeyNotFoundException), "El Tipo no existe")]
        [TestMethod]
               public void UpdateTipoNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

            int id =1;
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };
            using (var context = new IMMRequestContext(options))
            {

                var manager = new TipoRepository(context);
                t.nombre="test2";
                manager.Update(t);
                manager.Save();
                Assert.AreEqual(manager.Get(id).nombre, "test2");
            }
        }

         [TestMethod]
        public void GetAll()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase3")
            .Options;

            int id =1;
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };
            using (var context = new IMMRequestContext(options))
            {
                 var manager = new TipoRepository(context);
                manager.Add(t);
                manager.Save();
                List<TipoDeTema> list = manager.GetAll().ToList();
                Assert.AreEqual(list.Count, 1);
                context.Set<TipoDeTema>().Remove(t);
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
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };
            using (var context = new IMMRequestContext(options))
            {
                 var manager = new TipoRepository(context);
                manager.Add(t);
                manager.Save();
                TipoDeTema res = manager.Get(id);
                Assert.AreEqual(res, t);
                context.Set<TipoDeTema>().Remove(t);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Tipo no existe")]
       [TestMethod]
        public void GetByIdNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

             int id =1;
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };
            using (var context = new IMMRequestContext(options))
            {
                 var manager = new TipoRepository(context);
                TipoDeTema res = manager.Get(id);
                Assert.AreEqual(res, t);
                context.Set<TipoDeTema>().Remove(t);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetByStringExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

             int id =1;
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };

            using (var context = new IMMRequestContext(options))
            {

                 var manager = new TipoRepository(context);
                manager.Add(t);
                manager.Save();
                TipoDeTema res = manager.GetByString(t.nombre);
                Assert.AreEqual(res, t);
                context.Set<TipoDeTema>().Remove(t);
                context.SaveChanges();

            }
        }


        [ExpectedException(typeof(KeyNotFoundException), "El Tipo no existe")]
           [TestMethod]
        public void GetByStringNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

             int id =1;
             TipoDeTema t = new TipoDeTema(){
                nombre = "test"
            };

            using (var context = new IMMRequestContext(options))
            {

                 var manager = new TipoRepository(context);
                TipoDeTema res = manager.GetByString(t.nombre);
                Assert.AreEqual(res, t);
                context.Set<TipoDeTema>().Remove(t);
                context.SaveChanges();

            }
        }
       
        
    }
}