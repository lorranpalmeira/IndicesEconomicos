using IndiceEconomicoAPI.Controllers;
using IndiceEconomicoAPI.Indices;
using Newtonsoft.Json;
using System;
using Xunit;

namespace IndicesAPITestes.IndicesTestes
{
    public class CdiTestes
    {
        [Fact]
        public void CdiDiarioTeste() {
            var indice = new Indice();
            indice.NomeIndice = "CDIDiario";
            var getIndice = new CdiController();

            var resultado = getIndice.CdiDiario();

            Indice i = JsonConvert.DeserializeObject<Indice>(resultado.ToString());
            string nomeIndice = i.NomeIndice;

            Assert.Equal(nomeIndice, indice.NomeIndice);
        }


        [Fact]
        public void MediaCdiIsValid() {
            var mediaCdi = new CdiController();
            var resultado = mediaCdi.MediaCdi();

            Assert.Equal("6.39",resultado);
        }

        [Fact]
        public void MediaCdiIsLowerThenZero()
        {
            var mediaCdi = new CdiController();
            var resultado = mediaCdi.MediaCdi();

            var validar = Convert.ToDouble(resultado) < 0.0 ? true : false;
            
            Assert.False(validar);
        }

        [Fact]
        public void MediaCdiIsGreaterThenZero()
        {
            var mediaCdi = new CdiController();
            var resultado = mediaCdi.MediaCdi();

            var validar = Convert.ToDouble(resultado) > 0.0 ? true : false;

            Assert.True(validar);
        }

    }
}
