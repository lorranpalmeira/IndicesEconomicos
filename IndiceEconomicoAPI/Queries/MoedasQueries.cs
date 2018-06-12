using IndiceEconomicoAPI.Indices;
using IndiceEconomicoAPI.MongoDriver;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IndiceEconomicoAPI.Queries
{
    public class MoedasQueries : IMoedasQueries
    {

        private MongoDbContext _dbContext;

        public MoedasQueries()
        {
            _dbContext = new MongoDbContext();
        }

        public double UsdBrl() {

            //var result = _dbContext.Moedas.Find(x => true).ToList();

            var valor =
               from x in _dbContext.Moedas.Find(m => true).ToList()
               where x.Data == DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy")
                select (x.Valor);

            var resultado = valor.SingleOrDefault();

            return resultado;
        }

    }
}
