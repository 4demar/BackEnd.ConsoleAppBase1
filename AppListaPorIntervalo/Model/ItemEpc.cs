using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ConsoleApp1.ListaPorIntervalo.Model
{
    public class ItemEpc
    {
        public string _id { get; set; }
        public string NomeReader { get; set; }
        public string Hex { get; set; }
        public string Barcode { get; set; }
        public string Tid { get; set; }
        public DateTime Data { get; set; }
        public ObjectId IdReader { get; set; }

        [BsonIgnore]
        public bool ItemComAlerta { get; set; } = false;
    }
}
