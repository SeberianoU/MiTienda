using System.Data.Entity;

namespace BL_MiNegocio
{
    public class CancelarCambios
    {
        Contexto _contexto;
        public CancelarCambios()
        {
            _contexto = new Contexto();
        }

        public void CancelarC()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }
    }
}
