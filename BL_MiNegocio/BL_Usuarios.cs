using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_MiNegocio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public Byte[] Foto { get; set; }
        public string Departamento { get; set; }
        public string Permisos { get; set; }
        public bool Estado { get; set; }
    }

    public class BL_Usuarios
    {
        Contexto _contexto;
        public BindingList<Usuario> listaUsuarios { get; set; }

        public BL_Usuarios()
        {
            _contexto = new Contexto();
            listaUsuarios = new BindingList<Usuario>();
        }

        public BindingList<Usuario> ObtenerUsuarios()
        {
            _contexto.Usuarios.Load();
            listaUsuarios = _contexto.Usuarios.Local.ToBindingList();
            return listaUsuarios;
        }


        public BindingList<Usuario> ObtenerUsuarios(string nombreUsuario)
        {
            var consulta = listaUsuarios.Where(p => p.NombreUsuario == nombreUsuario).ToList();
            var resultado = new BindingList<Usuario>(consulta);

            return resultado;
        }

        public void AgregarUsuario()
        {
            var nuevoUsuario = new Usuario();
            _contexto.Usuarios.Add(nuevoUsuario);
        }

        public Resultado GuardarUsuario(Usuario usuario)
        {
            var resultado = Validar(usuario);
            if (resultado.Correcto == true)
            {
                return resultado;
            }
            _contexto.SaveChanges();
            resultado.Correcto = true;

            return resultado;
        }

        public bool EliminarUsuario(int id)
        {
            foreach (var usuario in listaUsuarios.ToList())
            {
                if (usuario.Id == id)
                {
                    listaUsuarios.Remove(usuario);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private Resultado Validar(Usuario usuario)
        {
            var resultado = new Resultado();
            if (usuario.NombreUsuario == "")
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Ingrese un nombre de usuario";
            }

            if (usuario.Contraseña == "")
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Ingrese una contraseña de usuario";
            }

            if (usuario.Estado == false)
            {
                resultado.Correcto = false;
                resultado.Mensaje = "Error, usted no tiene autorización para ingresar al sistema, contacte a su administrador";
            }

            return resultado;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

    }

}
