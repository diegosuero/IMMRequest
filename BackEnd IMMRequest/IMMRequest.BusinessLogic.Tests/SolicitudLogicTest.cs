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
    public class SolicitudLogicTest
    {
            //dotnet test /p:CollectCoverage=true


        [ExpectedException(typeof(ArgumentException), "Email invalido")]
        [TestMethod]
        public void CrearSolicitudMailInvalidoTest()
        {
            //Area a = CrearAreaValidoTesting();
            Solicitud s = new Solicitud(){
                nombre = "diego",
                mail ="D@dcom",
                telefono = "2",
                Area = null
            };
            var mock = new Mock<IRepository<Solicitud>>(MockBehavior.Strict);
            var mockArea = new Mock<ILogic<Area>>(MockBehavior.Strict);
            var mockTema = new Mock<ILogic<Tema>>(MockBehavior.Strict);
            var mockTipo = new Mock<ILogic<TipoDeTema>>(MockBehavior.Strict);
            var mockLogicCampotexto = new Mock<ILogic<CampoAicionalTexto>>(MockBehavior.Strict);
            var mockLogicCampoFecha = new Mock<ILogic<CampoAdicionalFecha>>(MockBehavior.Strict);
            var mockLogicCampoEntero = new Mock<ILogic<CampoAdicionalEntero>>(MockBehavior.Strict);
            var SolicitudLogic = new SolicitudLogic(mock.Object,mockArea.Object,mockTema.Object,mockTipo.Object,mockLogicCampotexto.Object,mockLogicCampoFecha.Object,mockLogicCampoEntero.Object);
            var AreaLogic = mockArea.Object;
            var v = SolicitudLogic.Create(s);
            mock.VerifyAll();
        }

        [ExpectedException(typeof(ArgumentException), "Solicitud Invalida")]
        [TestMethod]
        public void CrearSolicitudMailValidoAreaInvalidaTest()
        {
            Solicitud s = new Solicitud(){
                nombre = "diego",
                mail ="D@d.com",
                telefono = "2",
                Area = new Area(){
                    Nombre="area"
                }
            };
            var mock = new Mock<IRepository<Solicitud>>(MockBehavior.Strict);
            var mockArea = new Mock<ILogic<Area>>(MockBehavior.Strict);
            var mockTema = new Mock<ILogic<Tema>>(MockBehavior.Strict);
            mockArea.Setup(m => m.GetByString(s.Area.Nombre)).Throws<ArgumentException>();
            var mockTipo = new Mock<ILogic<TipoDeTema>>(MockBehavior.Strict);
            var mockLogicCampotexto = new Mock<ILogic<CampoAicionalTexto>>(MockBehavior.Strict);
            var mockLogicCampoFecha = new Mock<ILogic<CampoAdicionalFecha>>(MockBehavior.Strict);
            var mockLogicCampoEntero = new Mock<ILogic<CampoAdicionalEntero>>(MockBehavior.Strict);
            var SolicitudLogic = new SolicitudLogic(mock.Object,mockArea.Object,mockTema.Object,mockTipo.Object,mockLogicCampotexto.Object,mockLogicCampoFecha.Object,mockLogicCampoEntero.Object);
            var AreaLogic = mockArea.Object;
            var result = SolicitudLogic.Create(s);
            mock.VerifyAll();
        }

       //[TestMethod]
        public void CrearSolicitudMailValidoAreaValidaTest()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "IMMRequestDB")
            .Options;

            Solicitud s = new Solicitud(){
                nombre = "diego",
                mail ="D@d.com",
                telefono = "2",
                Area = new Area("Limpieza")
            };
            var mock = new Mock<IRepository<Solicitud>>(MockBehavior.Strict);
            var mockArea = new Mock<ILogic<Area>>(MockBehavior.Strict);
            var mockTema = new Mock<ILogic<Tema>>(MockBehavior.Strict);
            var mockLogicCampotexto = new Mock<ILogic<CampoAicionalTexto>>(MockBehavior.Strict);
            var mockLogicCampoFecha = new Mock<ILogic<CampoAdicionalFecha>>(MockBehavior.Strict);
            var mockLogicCampoEntero = new Mock<ILogic<CampoAdicionalEntero>>(MockBehavior.Strict);
            var mockTipo = new Mock<ILogic<TipoDeTema>>(MockBehavior.Strict);

            mockArea.Setup(m => m.GetByString(s.Area.Nombre)).Returns(s.Area);
            mockArea.Setup(m => m.GetByString(s.Area.Nombre)).Returns(s.Area);

            var SolicitudLogic = new SolicitudLogic(mock.Object,mockArea.Object,mockTema.Object,mockTipo.Object,mockLogicCampotexto.Object,mockLogicCampoFecha.Object,mockLogicCampoEntero.Object);

            //mockArea.Setup(m => m.Get(s.Area.Id)).Returns(s.Area);
           // mockArea.Setup(m => m.Create(s.Area)).Returns(s.Area);
            //mockArea.Setup(m => m.GetByString(s.Area.Nombre)).Returns(s.Area);
            var AreaLogic = mockArea.Object;
            var result = SolicitudLogic.Create(s);

            mock.VerifyAll();
        }
        

        [ExpectedException(typeof(ArgumentException), "Tema Invalido")]
        //[TestMethod]
         public void CrearSolicitudAreaValidaTemaInvalidoTest()
        {
            var options = new DbContextOptionsBuilder<IMMRequestContext>()
            .UseInMemoryDatabase(databaseName: "IMMRequestDB")
            .Options;

            Solicitud s = new Solicitud(){
                nombre = "diego",
                mail ="D@d.com",
                telefono = "2",
                Area = CrearAreaValidoTesting(),
                Tema = new Tema(){Nombre="a"}
            };


            var mock = new Mock<IRepository<Solicitud>>(MockBehavior.Strict);
            var mockArea = new Mock<ILogic<Area>>(MockBehavior.Strict);
            var mockTema = new Mock<ILogic<Tema>>(MockBehavior.Strict);
            var mockLogicCampotexto = new Mock<ILogic<CampoAicionalTexto>>(MockBehavior.Strict);
            var mockLogicCampoFecha = new Mock<ILogic<CampoAdicionalFecha>>(MockBehavior.Strict);
            var mockLogicCampoEntero = new Mock<ILogic<CampoAdicionalEntero>>(MockBehavior.Strict);
            var mockTipo = new Mock<ILogic<TipoDeTema>>(MockBehavior.Strict);
            var SolicitudLogic = new SolicitudLogic(mock.Object,mockArea.Object,mockTema.Object,mockTipo.Object,mockLogicCampotexto.Object,mockLogicCampoFecha.Object,mockLogicCampoEntero.Object);
            //AreaLogic.Create(s.Area);
            var result = SolicitudLogic.Create(s);

            mock.VerifyAll();
        }




        public Area CrearAreaValidoTesting(){
            List<Tema> temas = new List<Tema>();
            Tema t = CrearTemaValidoTesting();
            temas.Add(t);
            Area a = new Area("Transporte"){
                Temas=temas
            };
            return a;
        }

        public Tema CrearTemaValidoTesting(){
            List<TipoDeTema> tipos = new List<TipoDeTema>();
            tipos.Add(CrearTipoValidoTesting());
            Tema t = new Tema(){
                Nombre = "Acoso Sexual",
                Tipos= tipos
            };
            return t;
        }

        public TipoDeTema CrearTipoValidoTesting(){
            TipoDeTema tipo = new TipoDeTema(){
                nombre = "Taxi"
            };
            return tipo;
        }
    }
}