using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.Regla.ObtenerReglaPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.ObtenerReglaPorId;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Regla.ObtenerReglaPorId;

namespace ArsCodex.LogicaDeNegocios.Regla.ObtenerReglaPorId
{
    public class ObtenerReglaPorIdLN : IObtenerReglaPorIdLN
    {
        private readonly IObtenerReglaPorIdAD _obtenerReglaPorIdAD;
        public ObtenerReglaPorIdLN()
        {
            _obtenerReglaPorIdAD = new ObtenerReglaPorIdAD();
        }
        public ReglaDto Obtener(int id)
        {
            ReglaDto reglaDto = _obtenerReglaPorIdAD.Obtener(id);
            return reglaDto;
        }
    }
}
