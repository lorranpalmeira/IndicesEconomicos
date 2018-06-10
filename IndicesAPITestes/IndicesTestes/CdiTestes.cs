using IndiceEconomicoAPI.Controllers;
using IndiceEconomicoAPI.Indices;
using IndiceEconomicoAPI.MongoDriver;
using IndiceEconomicoAPI.Queries;
using MongoDB.Driver;
using Moq;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using Xunit;

namespace IndicesAPITestes.IndicesTestes
{
    public class CdiTestes
    {

        private CdiController _controller;

        public CdiTestes()
        {
            _controller = new CdiController();
        }

       


        [Fact]
        public void MediaCdiIsValid() {

            var cdi = new Cdi() {
                Valor = 7.11
            };

            var mock = new Mock<ICdiQueries>();

            var valor = 7.11 ;
            mock.Setup(m => m.CdiMedia()).Returns(valor);

            var resultadoEsperado = mock.Object.CdiMedia();
                      

            Assert.Equal(resultadoEsperado, cdi.Valor);
        }

        [Fact]
        public void MediaCdiIsLowerThenZero()
        {
            var resultado = _controller.MediaCdi();

            var validar = Convert.ToDouble(resultado) < 0.0 ? true : false;
            
            Assert.False(validar);
        }

        [Fact]
        public void MediaCdiIsGreaterThenZero()
        {
            var resultado = _controller.MediaCdi();

            var validar = Convert.ToDouble(resultado) > 0.0 ? true : false;

            Assert.True(validar);
        }

    }
}
