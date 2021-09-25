using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BL_MiNegocio
{
    public class Contexto : DbContext
    {
        public Contexto() : base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" + 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MiNegocio.mdf")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}