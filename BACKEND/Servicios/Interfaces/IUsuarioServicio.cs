using System;
using System.Threading.Tasks;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;

namespace BACKEND.Servicios.Interfaces
{
    public interface IUsuarioServicio
    {
        DatosUsuarioDTO? ValidarUsuario(CredencialesDTO usuario);

        bool CreacionCliente(NuevoUsuarioDTO usuario);
    }
}