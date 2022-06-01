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
    public class SessionRepositoryTest
    {

        
    //dotnet test /p:CollectCoverage=true
    
        [TestMethod]
        public void AddSession()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };

            AdminSession session = new AdminSession(){
                Id =id,
                Token= 12,
                admin=administrador
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SessionsRepository(context);
                manager.Add(session);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 1);
                context.Set<AdminSession>().Remove(session);
                context.SaveChanges();
            }
        }


        [TestMethod]
        public void RemoveSessionExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

            int id =11;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };

            AdminSession session = new AdminSession(){
                Id =id,
                Token= 12,
                admin=administrador
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SessionsRepository(context);
                context.Set<AdminSession>().Add(session);
                context.SaveChanges();
                manager.Remove(session);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "La Sesion no existe")]
        [TestMethod]
        public void RemoveSessionNotExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase3")
            .Options;

            int id =11;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };

            AdminSession session = new AdminSession(){
                Id =id,
                Token= 12,
                admin=administrador
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SessionsRepository(context);
                manager.Remove(session);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);
            }
        }

        [TestMethod]
        public void UpdateSessionExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

            int id =2;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };

            AdminSession session = new AdminSession(){
                Id =id,
                Token= 11,
                admin=administrador
            };
            using (var context = new IMMRequestContext(options))
            {
                context.Set<AdminSession>().Add(session);
                context.SaveChanges();
                var manager = new SessionsRepository(context);
                session.Token = 12;
                manager.Update(session);
                manager.Save();
                Assert.AreEqual(manager.Get(id).Token, 12);
                context.Set<AdminSession>().Remove(session);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "La Sesion no existe")]
        [TestMethod]
        public void UpdateSessionNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

            int id =22323;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };

            AdminSession session = new AdminSession(){
                Id =id,
                Token= 11,
                admin=administrador
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SessionsRepository(context);
                session.Token = 12;
                manager.Update(session);
                manager.Save();
            }
        }

        [TestMethod]
        public void GetAll()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase3")
            .Options;

            int id =22323;

            AdminSession session = new AdminSession(){
                Id =id,
                Token= 11,
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SessionsRepository(context);
                manager.Add(session);
                manager.Save();
                List<AdminSession> list = manager.GetAll().ToList();
                Assert.AreEqual(list.Count, 1);
                context.Set<AdminSession>().Remove(session);
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

            AdminSession session = new AdminSession(){
                Id =id,
                Token= 11,
            };
            using (var context = new IMMRequestContext(options))
            {
                context.Set<AdminSession>().Add(session);
                context.SaveChanges();
                var manager = new SessionsRepository(context);
                AdminSession res = manager.Get(id);
                Assert.AreEqual(res, session);
                context.Set<AdminSession>().Remove(session);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "La Sesion no existe")]
        [TestMethod]
        public void GetByIdNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase1")
            .Options;

            int id =22323;
            using (var context = new IMMRequestContext(options))
            {
                var manager = new SessionsRepository(context);
                AdminSession res = manager.Get(id);
                Assert.AreEqual(res, null);
            }
        }

        [TestMethod]
        public void GetByStringExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

            int id =22;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };

            AdminSession session = new AdminSession(){
                Id =id,
                Token= 11,
                admin=administrador
            };
            using (var context = new IMMRequestContext(options))
            {
                context.Set<AdminSession>().Add(session);
                context.SaveChanges();
                var manager = new SessionsRepository(context);
                AdminSession a = manager.GetByString(session.Token.ToString());
                Assert.AreEqual(session, a);
                context.Set<AdminSession>().Remove(session);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "La Sesion no existe2")]
        [TestMethod]
        public void GetByStringNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

            using (var context = new IMMRequestContext(options))
            {
                var manager = new SessionsRepository(context);
                AdminSession a = manager.GetByString("12554");
                Assert.AreEqual(null, a);
            }
        }

        


                
    }
}