using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BACKEND.Modelos
{
    public class CopiaLibro
    {
        [BsonElement("copyId")]
        public int copyId {  get; set; }

        [BsonElement("editorial")]
        public string editorial {  get; set; }

        [BsonElement("estado")]
        public string estado { get; set; }

        [BsonElement("eliminado")]
        public bool eliminado { get; set; } = false;
    }
}