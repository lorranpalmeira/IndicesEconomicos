using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IndiceEconomicoAPI.Indices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IndiceEconomicoAPI.Controllers
{
    [Route("api/[controller]")]
    public class IndicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cdi() {

            return View();
        }

        [HttpGet("GetIndiceCdi")]
        public string GetIndiceCdiDiario()
        {
            Indice indice = new Indice()
            {
                NomeIndice = "CDI",
                Taxa = 0.25,
                Data = DateTime.Now.ToLocalTime()
            };

            string json = JsonConvert.SerializeObject(indice);

            return json;

            
        }
    }
}