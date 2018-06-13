using IndiceEconomicoAPI.Indices;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiceEconomicoAPI.MongoDriver
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        public IMongoDatabase _database { get; }
        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        /*
        public IMongoCollection<T> Query
        {
            get
            {
                return _database.GetCollection<T>(nameof(T));
            }
        }
        */
        
        
        

        public IMongoCollection<Cdi> Cdi
        {
            get
            {
                return _database.GetCollection<Cdi>("Cdi");
            }
        }

        public IMongoCollection<Moedas> Moedas
        {
            get
            {
                return _database.GetCollection<Moedas>("Moedas");
            }
        }
    }
}
