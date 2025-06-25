using System;

namespace BACKEND.DTO.Recibe
{
    public class NuevoUsuarioDTO
    {
        public string Nombre { get; set; } = string.Empty;

        public string ApellidoPaterno { get; set; } = string.Empty;

        public string ApellidoMaterno { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; }

        public int Carnet { get; set; }

        public string Contrasena { get; set; } = string.Empty;
    }
}