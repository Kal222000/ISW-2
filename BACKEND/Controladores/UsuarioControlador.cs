using System;
using Microsoft.AspNetCore.Mvc;
using BACKEND.DTO.Envia;
using BACKEND.DTO.Recibe;
using BACKEND.Servicios;
using BACKEND.Servicios.Interfaces;

namespace BACKEND.Controladores
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioControlador : ControllerBase
    {
        private readonly IUsuarioServicio servicio;

        public UsuarioControlador()
        {
            servicio = new UsuarioServicio();
        }

        [HttpPost("ValidarUsuario")]
        public IActionResult ValidarUsuario([FromBody] CredencialesDTO usuario)
        {
            var resultado = servicio.ValidarUsuario(usuario);

            return Ok(resultado);
        }

        [HttpPost("CreacionCliente")]
        public IActionResult CreacionCliente([FromBody] NuevoUsuarioDTO usuario)
        {
            try
            {
                var resultado = servicio.CreacionCliente(usuario);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}