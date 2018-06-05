using IndiceEconomicoAPI.Indices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace IndiceEconomicoAPI.Controllers
{
    [Route("api/[controller]")]
    public class CdiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("CdiDiario")]
        public string CdiDiario()
        {
            Indice indice = new Indice()
            {
                NomeIndice = "CDIDiario",
                Taxa = 0.25,
                Data = DateTime.Now
            };

            string json = JsonConvert.SerializeObject(indice);

            return json;
        }
    }
}