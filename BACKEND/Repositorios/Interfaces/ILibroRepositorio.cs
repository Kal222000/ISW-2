using System;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using System.Collections.Generic;

namespace BACKEND.Repositorios.Interfaces
{
    public interface ILibroRepositorio
    {
        List<LibroDTO> DevolverLibros();

        void Anadirfavorito(LibroDTO l);

        /*   int CantidadCopiasDisponibles();

            void CrearLibro();

            void ActualizarCopia();*/
    }
}