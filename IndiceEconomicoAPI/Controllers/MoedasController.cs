using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IndiceEconomicoAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoedasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //http://free.currencyconverterapi.com/api/v5/convert?q=USD_BRL&compact=y

        [HttpGet("UsdBrl")]
        public string UsdBrl() {

            WebClient client = new WebClient();
            var ret = client.DownloadString("http://free.currencyconverterapi.com/api/v5/convert?q=USD_BRL&compact=y");

            //ret["val"].ToString()
            var json = JsonConvert.SerializeObject(ret);
            
            

            return ret;
        }
    }
}