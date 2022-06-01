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
    public class CampoAdicionalFechaRepositoryTest
    {
        //dotnet test /p:CollectCoverage=true

        [TestMethod]
        public void AddCampo()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;
            
            int id =1;
           CampoAdicionalFecha campo = new CampoAdicionalFecha(){
             Nombre = "test" 
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new CampoAdicionalFechaRepository(context);
                manager.Add(campo);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 1);
                context.Set<CampoAdicionalFecha>().Remove(campo);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void RemoveCampoExist()
        {
           var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;
           CampoAdicionalFecha campo = new CampoAdicionalFecha(){
             Nombre = "test" 
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new CampoAdicionalFechaRepository(context);
                context.Set<CampoAdicionalFecha>().Add(campo);
                context.SaveChanges();
                manager.Remove(campo);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);

            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Campo no existe")]
        [TestMethod]
        public void RemoveCampoNotExist()
        {
           var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase20")
            .Options;

            int id =1;
           CampoAdicionalFecha campo = new CampoAdicionalFecha(){
             Nombre = "test" 
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new CampoAdicionalFechaRepository(context);
                context.SaveChanges();
                manager.Remove(campo);
                manager.Save();
                Assert.AreEqual(manager.GetAll().ToList().Count, 0);

            }
        }

        [TestMethod]
        public void UpdateCampoExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

           
           int id =1;
           CampoAdicionalFecha campo = new CampoAdicionalFecha(){
             Nombre = "test",
             Id=id 
           };
            using (var context = new IMMRequestContext(options))
            {
                context.Set<CampoAdicionalFecha>().Add(campo);
                context.SaveChanges();
                var manager = new CampoAdicionalFechaRepository(context);
                campo.Nombre = "campo2";
                manager.Update(campo);
                manager.Save();
                Assert.AreEqual(manager.Get(id).Nombre, "campo2");
                context.Set<CampoAdicionalFecha>().Remove(campo);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Campo no existe")]
        [TestMethod]
        public void UpdateCampoNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase4")
            .Options;

           
           int id =1;
           CampoAdicionalFecha campo = new CampoAdicionalFecha(){
             Nombre = "test" 
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new CampoAdicionalFechaRepository(context);
                campo.Nombre = "campo2";
                manager.Update(campo);
                manager.Save();
                Assert.AreEqual(manager.Get(id).Nombre, "campo2");
            }
        }

         [TestMethod]
        public void GetAll()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase3")
            .Options;

            int id =1;
           CampoAdicionalFecha campo = new CampoAdicionalFecha(){
             Nombre = "test" 
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new CampoAdicionalFechaRepository(context);
                manager.Add(campo);
                manager.Save();
                List<CampoAdicionalFecha> list = manager.GetAll().ToList();
                Assert.AreEqual(list.Count, 1);
                context.Set<CampoAdicionalFecha>().Remove(campo);
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
           CampoAdicionalFecha campo = new CampoAdicionalFecha(){
             Nombre = "test",
             Id=id 
           };
            using (var context = new IMMRequestContext(options))
            {
                var manager = new CampoAdicionalFechaRepository(context);
                manager.Add(campo);
                manager.Save();
                CampoAdicionalFecha res = manager.Get(id);
                Assert.AreEqual(res, campo);
                context.Set<CampoAdicionalFecha>().Remove(campo);
                context.SaveChanges();
            }
        }

        [ExpectedException(typeof(KeyNotFoundException), "El Campo no existe")]
        [TestMethod]
        public void GetByIdNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase2")
            .Options;


            using (var context = new IMMRequestContext(options))
            {
                var manager = new CampoAdicionalFechaRepository(context);
                CampoAdicionalFecha res = manager.Get(33);
                Assert.AreEqual(res, null);
            }
        }

        [TestMethod]
        public void GetByStringExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

           CampoAdicionalFecha campo = new CampoAdicionalFecha(){
             Nombre = "test" 
           };

            using (var context = new IMMRequestContext(options))
            {
                context.Set<CampoAdicionalFecha>().Add(campo);
                context.SaveChanges();
                var manager = new CampoAdicionalFechaRepository(context);
                CampoAdicionalFecha res = manager.GetByString(campo.Nombre);
                Assert.AreEqual(res, campo);
                context.Set<CampoAdicionalFecha>().Remove(campo);
                context.SaveChanges();
            }
        }


        [ExpectedException(typeof(KeyNotFoundException), "El Campo no existe")]
        [TestMethod]
        public void GetByStringNotExist()
        {
             var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "EjDataBase5")
            .Options;

            using (var context = new IMMRequestContext(options))
            {
                var manager = new CampoAdicionalFechaRepository(context);
                CampoAdicionalFecha res = manager.GetByString("string");
                Assert.AreEqual(res, null);

            }
        } 
    }        
    
}
