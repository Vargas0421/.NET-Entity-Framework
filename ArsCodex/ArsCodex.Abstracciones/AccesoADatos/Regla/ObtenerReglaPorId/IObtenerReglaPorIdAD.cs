using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.ModelosParaUI;

namespace ArsCodex.Abstracciones.AccesoADatos.Regla.ObtenerReglaPorId
{
    public interface IObtenerReglaPorIdAD
    {
        ReglaDto Obtener(int id);
    }
}
