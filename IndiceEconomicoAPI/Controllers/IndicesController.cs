using IndiceEconomicoAPI.Indices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace IndiceEconomicoAPI.Controllers
{
    [Route("api/[controller]")]
    public class IndicesController : Controller
    {
        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        

        [HttpGet("GetIndiceCdi")]
        public string GetIndiceCdiDiario()
        {
            Indice indice = new Indice()
            {
               
                Valor = "0.25",
               
            };

            string json = JsonConvert.SerializeObject(indice);

            return json;
        }

        // GET api/indices/GetIndice/m/igpm
        [HttpGet("GetIndice/{tipo}/{nomeIndice}")]
        public string GetIndice(string nomeIndice,string tipo )
        {
            return "Tipo: " + tipo +" - Indice:"+ nomeIndice;
        }
    }
}