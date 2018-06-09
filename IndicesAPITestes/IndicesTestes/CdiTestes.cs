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
        public void MediaCdiSizeIsValid() {

            var resultado = _controller.MediaCdi();

            var validar = Convert.ToDouble(resultado) > 0.0 ? true : false;

            var size = resultado.Length > 3 &&  resultado.Length < 5 ? true : false;

            Assert.True(size);
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
