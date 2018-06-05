using IndiceEconomicoAPI.Indices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net;

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

        [HttpGet("MediaCdi")]
        public string MediaCdi()
        {
            WebClient client = new WebClient();
            DateTime data = DateTime.Today.AddDays(-1);
            
            string dataFormatada = data.ToString("yyyyMMdd");
            var _mediaCdi = client.DownloadString(@"ftp://ftp.cetip.com.br/MediaCDI/"+ dataFormatada + ".txt");

            _mediaCdi = _mediaCdi.Substring(5, 4);
            _mediaCdi = _mediaCdi.Substring(0, 2) + "." + _mediaCdi.Substring(2, 2);
            _mediaCdi = _mediaCdi.StartsWith("0") ? _mediaCdi.Substring(1, 4) : _mediaCdi;

            var json = JsonConvert.SerializeObject(_mediaCdi);

            return _mediaCdi;
        }


        [HttpGet("FatorDiario")]
        public string FatorDiario()
        {
            //string json = JsonConvert.SerializeObject(indice);

            return "json";
        }


    }
}