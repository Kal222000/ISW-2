using System;
using BACKEND.DTO.Envia;
using System.Collections.Generic; 

namespace BACKEND.Servicios.Interfaces
{
    public interface ILibroServicio
    {
        List<LibroDTO> DevolverLibros();
    }
}