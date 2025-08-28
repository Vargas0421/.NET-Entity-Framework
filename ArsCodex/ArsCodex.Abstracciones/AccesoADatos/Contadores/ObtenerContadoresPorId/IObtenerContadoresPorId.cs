using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.Contadores.ObtenerContadoresPorId
{
    public interface IObtenerContadoresPorId
    {
        ContadoresDto ObtenerContadorPorId(int id);
    }
}
