using IndiceEconomicoAPI.Indices;
using IndiceEconomicoAPI.MongoDriver;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IndiceEconomicoAPI.Controllers
{
    [Route("api/[controller]")]
    public class CdiController : Controller
    {
        

        [HttpGet("CdiDiario")]
        public string CdiDiario()
        {
            Indice indice = new Indice();

            string json = JsonConvert.SerializeObject(indice);

            return json;
        }

        [HttpGet("MediaCdi")]
        public  string MediaCdi()
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

        [HttpGet("ListaMediaCdi")]
        public JsonResult ListaMediaCdi()
        {
            MongoDbContext dbContext = new MongoDbContext();
            List<Cdi> listaMediaCdi = dbContext.Notas.Find(m => true).ToList();
            return Json(listaMediaCdi);
        }


        [HttpGet("FatorDiario")]
        public string FatorDiario()
        {
            //string json = JsonConvert.SerializeObject(indice);

            return "json";
        }


    }
}