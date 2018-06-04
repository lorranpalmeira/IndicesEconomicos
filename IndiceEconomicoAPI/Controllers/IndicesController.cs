using IndiceEconomicoAPI.Indices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

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
                Data = DateTime.Now
            };

            string json = JsonConvert.SerializeObject(indice);

            return json;
        }

        // GET api/indices/5
        [HttpGet("{id}")]
        public string GetIndice(string indice)
        {
            return indice;
        }
    }
}