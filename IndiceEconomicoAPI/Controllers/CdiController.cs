using IndiceEconomicoAPI.Indices;
using IndiceEconomicoAPI.MongoDriver;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            List<Cdi> listaMediaCdi = dbContext.Cdi.Find(m => true).ToList();
            return Json(listaMediaCdi);
        }

        [HttpGet("MediaCdiV2")]
        public JsonResult MediaCdiV2()
        {
            MongoDbContext dbContext = new MongoDbContext();
            //List<Cdi> mediaCdi = dbContext.Cdi.Find(m => m.Data == "20180608").ToList();

            var valor =
                from x in dbContext.Cdi.Find(m => true).ToList()
                where x.Data == DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy")
                select (x.Valor);


            return Json(valor.SingleOrDefault());
        }

        [HttpGet("MediaCdiPeriodo/{d1}")]
        [HttpGet("MediaCdiPeriodo")]
        public JsonResult MediaCdiPeriodo(string d1)
        {
            MongoDbContext dbContext = new MongoDbContext();
            //List<Cdi> valores = dbContext.Cdi.Find(m => true).ToList();


            var valores =
                from x in dbContext.Cdi.Find(m => true).ToList()
                where DateTime.ParseExact(x.Data, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(d1, "ddMMyyyy", CultureInfo.InvariantCulture)
                select (x.Valor );




            return Json(valores);
        }


        [HttpGet("FatorDiario")]
        public string FatorDiario()
        {
            //string json = JsonConvert.SerializeObject(indice);

            return "json";
        }


    }
}