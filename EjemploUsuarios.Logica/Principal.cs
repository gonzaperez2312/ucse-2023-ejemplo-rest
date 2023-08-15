using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploUsuarios.Logica
{
    public class Principal
    {
        public Principal()
        {
        }

        public List<Usuario> ObtenerListadoUsuarios()
        {
            return Archivos.LeerDesdeArchivoJson();
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            List<Usuario> usuarios = ObtenerListadoUsuarios();

            if (usuarios != null)
                return usuarios.FirstOrDefault(u => u.Id == id);

            return null;
        }

        public Usuario DarDeAltaUsuario(Usuario usuario)
        {
            usuario.Id = ObtenerListadoUsuarios().Count + 1;
            usuario.Activo = true;
            usuario.FechaRegistro = DateTime.Now;

            Archivos.GuardarEnArchivoJson(usuario);

            return usuario;
        }

        public Usuario EditarUsuario(int id, Usuario usuarioModificado)
        {
            List<Usuario> usuarios = ObtenerListadoUsuarios();

            if (usuarios.Any(u => u.Id == id))
            {
                var usuarioAEditar = usuarios.Find(u => u.Id == id);
                
                usuarioAEditar = usuarioModificado;

                Archivos.GuardarEnArchivoJson(usuarioAEditar);

                return usuarioAEditar;
            }
            
            return null;
        }

        public bool EliminarUsuario(int id)
        {
            List<Usuario> usuarios = ObtenerListadoUsuarios();

            if (usuarios.Any(u => u.Id == id))
            {
                var usuarioAEliminar = usuarios.Find(u => u.Id == id);
                usuarioAEliminar.Activo = false;

                Archivos.GuardarEnArchivoJson(usuarioAEliminar);

                return true;
            }

            return false;
        }
    }
}
