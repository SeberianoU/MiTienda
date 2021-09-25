using System.Data.Entity;

namespace BL_MiNegocio
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuario1 = new Usuario();

            usuario1.Id = 1;
            usuario1.NombreUsuario = "Admin";
            usuario1.Contraseña = "123";
            usuario1.Nombre = "Administrador";
            usuario1.Apellido = "Sistema";
            usuario1.Estado = true;

            contexto.Usuarios.Add(usuario1);

            var usuario2 = new Usuario();

            usuario2.Id = 2;
            usuario2.NombreUsuario = "Sebe";
            usuario2.Contraseña = "123";
            usuario2.Nombre = "Caja";
            usuario2.Apellido = "Caja #2";
            usuario2.Estado = true;

            contexto.Usuarios.Add(usuario2);

            base.Seed(contexto);
        }
    }
}