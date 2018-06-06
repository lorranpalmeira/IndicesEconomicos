using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IndiceEconomicoAPI.Controllers
{

    [Route("api/[controller]")]
    public class IpcaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("IpcaNumeroIndiceUltimoMes")]
        public string IpcaNumeroIndiceUltimoMes() {

            //WebClient client = new WebClient();
            // var xml = client.DownloadString(@"http://api.sidra.ibge.gov.br/values/t/1737/n1/all//v/2266/p/201804");
            string xml = new WebClient().DownloadString(@"http://api.sidra.ibge.gov.br/values/t/1737/n1/all//v/2266/p/201804");
            
            XDocument doc = XDocument.Parse(xml);
            XmlNode myXmlNode = JsonConvert.DeserializeXmlNode(xml); // is node not note
                                                                              // or .DeserilizeXmlNode(myJsonString, "root"); // if myJsonString does not have a root
            string jsonString = JsonConvert.SerializeXmlNode(myXmlNode);

            return jsonString;
        }

    }
}