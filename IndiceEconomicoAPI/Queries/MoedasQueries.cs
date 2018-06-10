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
    public class MoedasQueries
    {

        private MongoDbContext _dbContext;

        public MoedasQueries()
        {
            _dbContext = new MongoDbContext();
        }

        public List<Moedas> UsdBrl() {

           var result = _dbContext.Moedas.Find(x => true).ToList();

            //var valor =
             //   from x in _dbContext.Moedas.Find(m => true);
               // where x. == DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy")
               // select (x.);

            return result;
        }

    }
}
