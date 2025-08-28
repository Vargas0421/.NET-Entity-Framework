using ArsCodex.Abstracciones.AccesoADatos.Regla.ActivarInactivarRegla;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Regla.ActivarInactivarRegla
{
    public class ActivarInactivarReglaAD : IActivarInactivarReglaAD
    {
        public async Task<bool> ToggleAsync(int idRegla)
        {
            using (var _contexto = new Contexto()) 
            {
                var regla = await _contexto.Set<ReglaAD>()
                                     .FirstOrDefaultAsync(r => r.IdRegla == idRegla);

                if (regla == null)
                    throw new InvalidOperationException($"No existe la regla con Id {idRegla}.");

                regla.Estado = !regla.Estado;                 // toggle
                regla.FechaDeModificacion = DateTime.Now;

                await _contexto.SaveChangesAsync();
                return regla.Estado;
            }
        }

    }
}
