using IndiceEconomicoAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IndicesAPITestes.IndicesTestes
{
    public class MoedasTestes
    {

        [Fact]
        public void UsdBrlAgoraIsGreaterThanZero() {
            var usdbrl = new MoedasController();

            var ret = usdbrl.UsdBrl();

            var validar = Convert.ToDouble(ret) > 0 ? true : false;

            Assert.True(validar);
        }
    }
}
