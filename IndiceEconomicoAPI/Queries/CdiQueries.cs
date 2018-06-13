using IndiceEconomicoAPI.Indices;
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

        private ListaColecoes<Cdi> _dbContextCdi;

        public CdiQueries()
        {
            _dbContext = new MongoDbContext();
            _dbContextCdi = new ListaColecoes<Cdi>();
        }



        public double CdiMedia() {

            var valor =
                from x in _dbContext.Cdi.Find(m => true).ToList()
                where x.Data == DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy")
                select (x.Valor);

            return valor.SingleOrDefault();
        }


        public double CdiMediaV2()
        {

            var valor =
                from x in  _dbContextCdi.Query.Find(m => true).ToList() //_dbContext.Cdi.Find(m => true).ToList()
                where x.Data == DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy")
                select (x.Valor);

            return valor.SingleOrDefault();
        }


    }
}
