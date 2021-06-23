using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using LogicaNegocios;
using WebApiRest.Controllers;
using System.Web.Http;
using LogicaNegocios.Clases;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UsuarioEnvia_DNI_Valido()
        {
            //arrange
            UsuarioEnvia usuario = new UsuarioEnvia();

            //act
            int resultado = usuario.ValidarExistenciaUsuarioEnvia(1);

            //assert
            Assert.AreEqual(1, resultado);
        }
        [TestMethod]
        public void UsuarioRecibe_DNI_Valido()
        {
            //arrange
            UsuarioRecibe usuario = new UsuarioRecibe();

            //act
            int resultado = usuario.ValidarExistenciaUsuarioRecibe(1);

            //assert
            Assert.AreEqual(1, resultado);
        }
        [TestMethod]
        public void MontoEnvio_Invalido()
        {
            //arrange
            Principal principal = new Principal();

            //act
            bool resultado = principal.ValidarMontoEnvio();

            //assert
            Assert.IsFalse(resultado);
        }
        public void MontoEnvio_Valido()
        {
            //arrange
            Principal principal = new Principal();

            //act
            bool resultado = principal.ValidarMontoEnvio();

            //assert
            Assert.IsTrue(resultado);
        }
    }
}