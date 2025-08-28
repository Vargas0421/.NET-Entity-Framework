using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.Comunes.Fecha
{
    public interface IFechaLN
    {
        DateTime ObtenerFechaPorZonaHoraria(int cantidadDeHoras);
    }
}
