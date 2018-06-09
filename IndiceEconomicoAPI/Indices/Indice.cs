using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiceEconomicoAPI.Indices
{
    public class Indice
    {

        public string NomeIndice { get; set; }

        public DateTime Data { get; set; }

        public string Periodicidade { get; set; }

        public string Valor { get; set; }
    }
}
