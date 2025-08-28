using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.Regla.ActivarInactivarRegla
{
    public interface IActivarInactivarReglaLN
    {
        Task<bool> Ejecutar(int idRegla);
    }
}
