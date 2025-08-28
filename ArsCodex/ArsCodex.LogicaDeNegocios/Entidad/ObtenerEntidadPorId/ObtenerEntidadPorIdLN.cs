using ArsCodex.Abstracciones.AccesoADatos.Entidad.ObtenerEntidadPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Entidades.ObtenerEntidadPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Entidad.ObtenerEntidadPorId
{
    public class ObtenerEntidadPorIdLN : IObtenerEntidadPorIdLN
    {
        private readonly IObtenerEntidadPorIdAD _ObtenerEntidadPorIdAD;
        public ObtenerEntidadPorIdLN()
        {
            _ObtenerEntidadPorIdAD = new ObtenerEntidadPorIdAD();
        }

        public EntidadDto Obtener(int id)
        {
            EntidadDto elEntidad = _ObtenerEntidadPorIdAD.Obtener(id);
            return elEntidad;
        }
    }
}
