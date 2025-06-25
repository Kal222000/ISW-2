using System;
using System.Data;
using System.Threading.Tasks;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using BACKEND.Datos.SQL;
using BACKEND.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BACKEND.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public DatosUsuarioDTO? ValidarUsuario(CredencialesDTO usuario)
        {
            int? usuarioid;

            using (var conexion = new SQLConexion())
            {
                var Carnet = new SqlParameter("@CARNET", usuario.Carnet);

                var Contrasena = new SqlParameter("@CONTRASENA", usuario.Contrasena);

                var Salida = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                var resultado = conexion.Database.ExecuteSqlRawAsync("EXEC ValidarUsuario @CARNET, @CONTRASENA, @ID OUTPUT",Carnet, Contrasena, Salida).Result;

                usuarioid = Salida.Value != DBNull.Value ? (int?) Salida.Value : null;

                if (usuarioid == null || usuarioid == 0)
                {
                    return null;
                }

                var usuariodb = conexion.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioid);

                if(usuariodb == null)
                {
                    return null;
                }

                return new DatosUsuarioDTO
                {
                    NombreCompleto = $"{usuariodb.Nombre} {usuariodb.ApellidoPaterno} {usuariodb.ApellidoMaterno}",
                    UsuarioId = usuariodb.UsuarioId,
                    Rol = usuariodb.Rol ?? 1
                };
            }
        }

        public bool CreacionCliente(NuevoUsuarioDTO usuario)
        {
            int? resultado;

            int aux = 1;

            using (var conexion = new SQLConexion())
            {
                var Nombre = new SqlParameter("@NOMBRE", usuario.Nombre);
                var ApellidoPaterno = new SqlParameter("@APELLIDOP", usuario.ApellidoPaterno);
                var ApellidoMaterno = new SqlParameter("@APELLIDOM", usuario.ApellidoMaterno);
                var FechaNacimiento = new SqlParameter("@FECHAN", SqlDbType.Date)
                {
                    Value = usuario.FechaNacimiento.Date
                };
                var Carnet = new SqlParameter("@CARNET", usuario.Carnet);
                var Rol = new SqlParameter("@ROL", SqlDbType.Int) { Value = aux };
                var Contrasena = new SqlParameter("@CONTRASENA", usuario.Contrasena);
                var Salida = new SqlParameter("@RESULTADO", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                var resultadoSP = conexion.Database.ExecuteSqlRawAsync("EXEC CreacionCliente @NOMBRE, @APELLIDOP, @APELLIDOM, @FECHAN, @CARNET, @ROL, @CONTRASENA, @RESULTADO OUTPUT", Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Carnet, Rol, Contrasena, Salida).Result;


                resultado = Salida.Value != DBNull.Value ? (int?) Salida.Value : null;

                if (resultado == 0)
                {
                    return true;
                }
                else { return false; }
            }
        }
    }
}