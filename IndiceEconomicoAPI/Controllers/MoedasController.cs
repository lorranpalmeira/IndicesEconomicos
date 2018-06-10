using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IndiceEconomicoAPI.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IndiceEconomicoAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoedasController : Controller
    {

        private MoedasQueries _moedas;

        public MoedasController()
        {
            _moedas = new MoedasQueries();
        }


        //http://free.currencyconverterapi.com/api/v5/convert?q=USD_BRL&compact=y

        [HttpGet("UsdBrl")]
        public string UsdBrl() {

            
            WebClient client = new WebClient();
            var ret = client.DownloadString("http://free.currencyconverterapi.com/api/v5/convert?q=USD_BRL&compact=y");
            
            
            JObject rss = JObject.Parse(ret);

            string rssJson = (string)rss["USD_BRL"]["val"];

            return rssJson;

        }

        [HttpGet("UsdBrlShort")]
        public string UsdBrlShort()
        {
            WebClient client = new WebClient();
            var ret = client.DownloadString("http://free.currencyconverterapi.com/api/v5/convert?q=USD_BRL&compact=y");

            JObject rss = JObject.Parse(ret);

            string rssJson = (string)rss["USD_BRL"]["val"];
            var realValue = rssJson.Substring(0,4);
            return realValue;
        }
    }
}