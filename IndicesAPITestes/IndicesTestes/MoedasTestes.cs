using IndiceEconomicoAPI.Controllers;
using IndiceEconomicoAPI.Indices;
using IndiceEconomicoAPI.Queries;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IndicesAPITestes.IndicesTestes
{
    public class MoedasTestes
    {

        

        [Fact]
        public void UsdBrlTeste() {

            var moedas = new Moedas()
            {
                Valor = 3.67
            };


            var mock = new Mock<IMoedasQueries>();

            mock.Setup(m=> m.UsdBrl()).Returns(3.67);

            var valorEsperado = mock.Object.UsdBrl();
            
            Assert.Equal(valorEsperado, moedas.Valor);
        }

        [Fact]
        public void UsdBrlIsGreaterThanZero() {

            
            var mock = new Mock<IMoedasQueries>();

            mock.Setup(m => m.UsdBrl()).Returns(-0.01);

            var valorEsperado = mock.Object.UsdBrl() > 0;

            Assert.False(valorEsperado);

        }

    }
}
