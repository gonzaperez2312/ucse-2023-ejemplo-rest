using EjemploUsuarios.Logica;
using Microsoft.AspNetCore.Mvc;

namespace EjemploUsuarios.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private Principal administrador;

        public UsuariosController()
        {
            administrador = new Principal();
        }

        [HttpGet("")]
        public IActionResult ObtenerUsuarios()
        {
            var usuarios = administrador.ObtenerListadoUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerUsuarioPorId(int id)
        {
            var usuario = administrador.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado.");
            }
            return Ok(usuario);
        }

        [HttpPost("")]
        public IActionResult DarDeAltaUsuario([FromBody] Usuario nuevoUsuario)
        {
            var altaUsuarioResponse = administrador.DarDeAltaUsuario(nuevoUsuario);

            if (altaUsuarioResponse != null)
            {
                return Ok(altaUsuarioResponse);
            }

            return BadRequest("Error en alta de usuario");
        }

        [HttpPut("{id}")]
        public IActionResult EditarUsuario(int id, [FromBody] Usuario usuarioModificado)
        {
            var editUsuarioResponse = administrador.EditarUsuario(id, usuarioModificado);

            if (editUsuarioResponse != null)
            {
                return Ok(editUsuarioResponse);
            }

            return NotFound($"Usuario con ID {id} no encontrado.");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var eliminarUsuarioResponse = administrador.EliminarUsuario(id);

            if (eliminarUsuarioResponse)
            {
                return Ok($"Usuario con ID {id} eliminado exitosamente.");
            }
            return NotFound($"Usuario con ID {id} no encontrado.");
        }
    }
}