using System;

namespace BACKEND.DTO.Envia
{
	public class DatosUsuarioDTO
	{
		public string NombreCompleto { get; set; } = string.Empty;

        public int Rol { get; set; }

		public int UsuarioId { get; set; }
	}
}