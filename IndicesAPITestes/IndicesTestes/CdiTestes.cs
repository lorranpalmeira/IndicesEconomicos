using IndiceEconomicoAPI.Controllers;
using IndiceEconomicoAPI.Indices;
using IndiceEconomicoAPI.MongoDriver;
using IndiceEconomicoAPI.Queries;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IndicesAPITestes.IndicesTestes
{
    public class CdiTestes
    {

        

        
        [Fact]
        public async Task TestGetMediaCdiAsync()
        {
            // Arrange
            var controller = new CdiController();

            // Act
            IActionResult actionResult = await controller.MediaCdi();

            // Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.NotNull(result);

            List<string> messages = result.Value as List<string>;

            //Assert.Equal(1, messages.Count);
            //Assert.Equal("6.79", messages[0]);
            //Assert.Equal("value2", messages[1]);
        }
        

        [Fact]
        public void MediaCdiTeste() {

            var cdi = new Cdi() {
                Valor = 7.11
            };

            var mock = new Mock<ICdiQueries>();

            var valor = 7.11 ;
            mock.Setup(m => m.CdiMedia()).Returns(valor);

            var resultadoEsperado = mock.Object.CdiMedia();
                      

            Assert.Equal(resultadoEsperado, cdi.Valor);
        }

        /*
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

    */

    }
}
