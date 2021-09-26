using System.Data.Entity;

namespace BL_MiNegocio
{
    public class Contexto : DbContext
    {
        public Contexto() : base("MiNegocioDB")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}