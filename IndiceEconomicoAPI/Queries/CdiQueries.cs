using IndiceEconomicoAPI.MongoDriver;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiceEconomicoAPI.Queries
{
    public class CdiQueries : ICdiQueries
    {

        private MongoDbContext _dbContext ;

        public CdiQueries()
        {
            _dbContext = new MongoDbContext();
        }

        public double CdiMedia() {

            var valor =
                from x in _dbContext.Cdi.Find(m => true).ToList()
                where x.Data == DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy")
                select (x.Valor);

            var resultado = Convert.ToDouble(valor);

            return resultado;
        }



    }
}
