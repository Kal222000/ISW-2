using System;
using System.Collections.Generic;
using BACKEND.DTO.Envia;
using BACKEND.Repositorios.Interfaces;
using BACKEND.Datos.Mongo;
using System.Linq;
using MongoDB.Driver;


namespace BACKEND.Repositorios
{
    public class LibroRepositorio : ILibroRepositorio
    {
        public List<LibroDTO> DevolverLibros()
        {
            var LibroColleccion = MongoConexion.ObtenerLibros();

            var Libros = LibroColleccion.Find(Libro => !Libro.eliminado).ToList();

            List<LibroDTO> lista = Libros.Select(Libro => new LibroDTO
            {
                Id = Libro._id,
                Titulo = Libro.titulo,
                Autor = Libro.autor
            }).ToList();

            return lista;
        }
    }
}