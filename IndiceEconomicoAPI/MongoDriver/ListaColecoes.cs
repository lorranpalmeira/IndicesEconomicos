using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiceEconomicoAPI.MongoDriver
{
    public class ListaColecoes<T> 
    {

        private IMongoDatabase _database { get; }

        public IMongoCollection<T> Query
        {
            get
            {
                return _database.GetCollection<T>(nameof(T));
            }
        }

    }
}
