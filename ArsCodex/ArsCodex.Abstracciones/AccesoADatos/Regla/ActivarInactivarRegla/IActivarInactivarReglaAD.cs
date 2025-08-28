using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.Regla.ActivarInactivarRegla
{
    public interface IActivarInactivarReglaAD
    {
        Task<bool> ToggleAsync(int idRegla);
    }
}
