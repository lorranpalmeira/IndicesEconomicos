using IndiceEconomicoAPI.Controllers;
using IndiceEconomicoAPI.Indices;
using Newtonsoft.Json;
using System;
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
        public void CdiDiarioTeste() {
            var indice = new Indice();
            indice.NomeIndice = "CDIDiario";
            //var getIndice = _controller;

            var resultado = _controller.CdiDiario();

            Indice i = JsonConvert.DeserializeObject<Indice>(resultado.ToString());
            string nomeIndice = i.NomeIndice;

            Assert.Equal(nomeIndice, indice.NomeIndice);
        }


        [Fact]
        public void MediaCdiIsValid() {
            //var mediaCdi = _controller;
            //var resultado = mediaCdi.MediaCdi();
            var resultado = _controller.MediaCdi();

            Assert.Equal("6.39",resultado);
        }

        [Fact]
        public void MediaCdiIsLowerThenZero()
        {
           // var mediaCdi = new CdiController();
            var resultado = _controller.MediaCdi();

            var validar = Convert.ToDouble(resultado) < 0.0 ? true : false;
            
            Assert.False(validar);
        }

        [Fact]
        public void MediaCdiIsGreaterThenZero()
        {
            //var mediaCdi = new CdiController();
            var resultado = _controller.MediaCdi();

            var validar = Convert.ToDouble(resultado) > 0.0 ? true : false;

            Assert.True(validar);
        }

    }
}
