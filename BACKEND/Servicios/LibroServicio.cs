using System;
using System.Collections.Generic;
using BACKEND.DTO.Envia;
using BACKEND.Repositorios;
using BACKEND.Repositorios.Interfaces;
using BACKEND.Servicios.Interfaces;

namespace BACKEND.Servicios
{
    public class LibroServicio : ILibroServicio
    {
        private readonly ILibroRepositorio repositorio;

        public LibroServicio()
        {
            repositorio = new LibroRepositorio();
        }

        public List<LibroDTO> DevolverLibros()
        {
            return repositorio.DevolverLibros();
        }
    }

}