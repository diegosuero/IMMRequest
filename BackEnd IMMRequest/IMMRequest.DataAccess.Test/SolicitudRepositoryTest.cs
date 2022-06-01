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
    public class SolicitudRepositoryTest
    {

        //dotnet test /p:CollectCoverage=true
        
        [TestMethod]
        public void AddSolicitud()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;

            Solicitud s = new Solicitud(){
                Id=id
            };
           
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SolicitudRepository(context);
                manager.Add(s);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 1);
                context.Set<Solicitud>().Remove(s);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void RemoveSolicitudExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;

            Solicitud s = new Solicitud(){
                Id=id
            };
           
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SolicitudRepository(context);
                context.Set<Solicitud>().Add(s);
                context.SaveChanges();
                manager.Remove(s);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "La solicitud no existe")]
        [TestMethod]
        public void RemoveSolicitudNotExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;

            Solicitud s = new Solicitud(){
                Id=id
            };
           
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SolicitudRepository(context);
                manager.Remove(s);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);
            }
        }

        [TestMethod]
        public void UpdateSolicitudExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

           
            int id =1;
            Solicitud s = new Solicitud(){
                Id=id,
                nombre = "diego"
            };
            using (var context = new IMMRequestContext(options))
            {
                context.Set<Solicitud>().Add(s);
                context.SaveChanges();
                var manager = new SolicitudRepository(context);;
                s.nombre = "pedro";
                manager.Update(s);
                manager.Save();
                Assert.AreEqual(manager.Get(id).nombre, "pedro");
                context.Set<Solicitud>().Remove(s);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "La solicitud no existe")]
        [TestMethod]
        public void UpdateSolicitudNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

           
            int id =1;
            Solicitud s = new Solicitud(){
                Id=id,
                nombre = "diego"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SolicitudRepository(context);
                manager.Update(s);
                manager.Save();
            }
        }

        [TestMethod]
        public void GetAll()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase3")
            .Options;

            int id =1;
            Solicitud s = new Solicitud(){
                Id=id,
                nombre = "diego"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SolicitudRepository(context);
                manager.Add(s);
                manager.Save();
                List<Solicitud> list = manager.GetAll().ToList();
                Assert.AreEqual(list.Count, 1);
                context.Set<Solicitud>().Remove(s);
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
            Solicitud s = new Solicitud(){
                Id=id,
                nombre = "diego"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SolicitudRepository(context);
                manager.Add(s);
                manager.Save();
                Solicitud res = manager.Get(id);
                Assert.AreEqual(res, s);
                context.Set<Solicitud>().Remove(s);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "La solicitud no existe")]
        [TestMethod]
        public void GetByIdNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

            int id =1;
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SolicitudRepository(context);
                Solicitud res = manager.Get(id);
                Assert.AreEqual(res, null);
            }
        }

        [TestMethod]
        public void GetByStringExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

             int id =1;
             String mail = "mail@mail.com";
            Solicitud s = new Solicitud(){
                Id=id,
                nombre = "diego",
                mail=mail
            };

            using (var context = new IMMRequestContext(options))
            {
                context.Set<Solicitud>().Add(s);
                context.SaveChanges();
                 var manager = new SolicitudRepository(context);
                Solicitud res = manager.GetByString(mail);
                Assert.AreEqual(res, s);
                context.Set<Solicitud>().Remove(s);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "La solicitud no existe")]
        [TestMethod]
        public void GetByStringNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

             int id =1;
             String mail = "mail@mail.com";

            using (var context = new IMMRequestContext(options))
            {
                 var manager = new SolicitudRepository(context);
                Solicitud res = manager.GetByString(mail);
                Assert.AreEqual(res, null);
            }
        }

    }
}