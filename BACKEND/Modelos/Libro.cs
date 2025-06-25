using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BACKEND.Modelos
{
    public class Libro
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)] 
        public string _id { get; set; }

        [BsonElement("titulo")]
        public string titulo { get; set; }

        [BsonElement("autor")]
        public string autor { get; set; }

        [BsonElement("genero")]
        public string genero { get; set; }

        [BsonElement("fechaPublicacion")]
        public DateTime fechaPublicacion { get; set; }

        [BsonElement("eliminado")]
        public bool eliminado { get; set; } = false;

        [BsonElement("copies")]
        public List<CopiaLibro> copies { get; set; } = new List<CopiaLibro>();
    }
}