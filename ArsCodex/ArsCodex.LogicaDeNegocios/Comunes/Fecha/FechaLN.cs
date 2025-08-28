
﻿using ArsCodex.Abstracciones.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArsCodex.Abstracciones.Comunes.Fecha;


namespace ArsCodex.LogicaDeNegocios.Comunes.Fecha
{
    public class FechaLN : IFechaLN
    {

        public DateTime ObtenerFechaPorZonaHoraria(int cantidadDeHoras)
        {
            return DateTime.UtcNow.AddHours(cantidadDeHoras);
        }
    }
}
