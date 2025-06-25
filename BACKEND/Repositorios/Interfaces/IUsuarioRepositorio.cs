using System;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using System.Threading.Tasks;

namespace BACKEND.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        DatosUsuarioDTO ValidarUsuario(CredencialesDTO usuario);

        bool CreacionCliente(NuevoUsuarioDTO usuario);
    }
}