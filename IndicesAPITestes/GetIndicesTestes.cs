using IndiceEconomicoAPI.Controllers;
using IndiceEconomicoAPI.Indices;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Xunit;

namespace IndicesAPITestes
{
    public class GetIndicesTestes
    {
        

        [Fact]
        public void GetIndiceCdiTeste()
        {

            var indice = new Indice();

            Assert.Equal(indice.NomeIndice, null);
        }


        [Fact]
        public void GetIndiceCdiControllerTeste() {
            var indice = new Indice();
            indice.NomeIndice = "CDI";
            var getIndice = new IndicesController();

            var resultado = getIndice.GetIndiceCdiDiario();

            Indice i = JsonConvert.DeserializeObject<Indice>(resultado.ToString());
            string nomeIndice = i.NomeIndice;

            Assert.Equal(nomeIndice, indice.NomeIndice);

        }


        [Fact]
        public void GetIndiceTeste() {

            var indice = new Indice();

            var retMethod = new IndicesController();
            var retorno = retMethod.GetIndice("CDI");
            
            Assert.Equal("CDI", retorno);
        }

    }
}
