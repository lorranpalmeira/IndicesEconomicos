using IndiceEconomicoAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IndicesAPITestes.IndicesTestes
{
    public class MoedasTestes
    {

        private MoedasController _moedas;

        public MoedasTestes()
        {
            _moedas = new MoedasController();
        }

        [Fact]
        public void UsdBrlAgoraIsGreaterThanZero() {
            
            var ret = _moedas.UsdBrl();

            var validar = Convert.ToDouble(ret) > 0 ? true : false;

            Assert.True(validar);
        }

        [Fact]
        public void UsdBrlSizeIsValid()
        {
            var ret = _moedas.UsdBrl();

            Assert.InRange(ret.Length, 8,8);

            
        }

        [Fact]
        public void UsdBrlShortSizeIsValid()
        {
            var ret = _moedas.UsdBrlShort();

            Assert.InRange(ret.Length, 3, 5);
            
        }

    }
}
