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

    //dotnet test /p:CollectCoverage=true

    [TestClass]
    public class AdministradorRepositoryTest
    {
        [TestMethod]
        public void AddAdmin()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

            int id =1;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                manager.Add(administrador);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 1);
                context.Set<Administrador>().Remove(administrador);
                context.SaveChanges();
            }
        }

  
        [TestMethod]
        public void RemoveAdminExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

            int id =1;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                context.Set<Administrador>().Add(administrador);
                context.SaveChanges();
                manager.Remove(administrador);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Administrador no existe")]
        [TestMethod]
        public void RemoveAdminNotExist()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

            int id =1;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                manager.Remove(administrador);
                manager.Save();
            }
        }


        [TestMethod]
        public void UpdateAdminExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

             int id =1;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };
            using (var context = new IMMRequestContext(options))
            {
                context.Set<Administrador>().Add(administrador);
                context.SaveChanges();
                var manager = new AdministradorRepository(context);
                administrador.Nombre = "Nombre";
                manager.Update(administrador);
                manager.Save();
                Assert.AreEqual(manager.Get(id).Nombre, "Nombre");
                context.Set<Administrador>().Remove(administrador);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Administrador no existe")]
        [TestMethod]
        public void UpdateAdminNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

             int id =1;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                administrador.Nombre = "Nombre";
                manager.Update(administrador);
                manager.Save();
                Assert.AreEqual(manager.Get(id).Nombre, "Nombre");
            }
        }

        [TestMethod]
        public void GetAll()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase")
            .Options;

           int id =1;
            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                manager.Add(administrador);
                manager.Save();
                List<Administrador> res= manager.GetAll().ToList();
                Assert.AreEqual(res.Count, 1);
                context.Set<Administrador>().Remove(administrador);
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

            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                manager.Add(administrador);
                manager.Save();
                Administrador res = manager.Get(id);
                Assert.AreEqual(res, administrador);
                context.Set<Administrador>().Remove(administrador);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Administrador no existe")]
        [TestMethod]
        public void GetByIdNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                Administrador res = manager.Get(1235);
                Assert.AreEqual(res, null);
            }
        }

        [TestMethod]
        public void GetByStringExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

            int id =22323;

            Administrador administrador= new Administrador(){
                Id = id,
                Nombre = "diego",
                Email = "test@test.com",
                Contrasena = "pass"
            };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                manager.Add(administrador);
                manager.Save();
                Administrador res = manager.GetByString(administrador.Email);
                Assert.AreEqual(res, administrador);
                context.Set<Administrador>().Remove(administrador);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Administrador no existe")]
        [TestMethod]
        public void GetByStringNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;

           
            using (var context = new IMMRequestContext(options))
            {
                var manager = new AdministradorRepository(context);
                Administrador res = manager.GetByString("nothing");
                Assert.AreEqual(res, null);
            }
        }
    }
}