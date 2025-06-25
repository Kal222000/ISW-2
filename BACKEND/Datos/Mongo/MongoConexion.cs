using MongoDB.Driver;
using BACKEND.Modelos;

namespace BACKEND.Datos.Mongo
{
    public class MongoConexion
    {
        public static string ConnectionString { get; set; } = "mongodb://localhost:27017";
        public static string DatabaseName { get; set; } = "Biblioteca";
        public static string CollectionName { get; set; } = "Libro";

        private static readonly MongoClient cliente = new MongoClient(ConnectionString);
        private static readonly IMongoDatabase basedatos = cliente.GetDatabase(DatabaseName);
        private static readonly IMongoCollection<Libro> Libros = basedatos.GetCollection<Libro>(CollectionName);

       static MongoConexion()
        {
        }

        public static IMongoCollection<Libro> ObtenerLibros()
        {
            return Libros;
        }
    }
}