using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IndiceEconomicoAPI.Indices
{
    public class Indice
    {
        public ObjectId _id { get; set; }

        /*
        [DataMember]
        public string MongoId
        {
            get { return _id.ToString(); }
            set { _id = ObjectId.Parse(value); }
        }
        */

        
        public string Data { get; set; }

        public string Periodicidade { get; set; }

        public double Valor { get; set; }
    }
}
