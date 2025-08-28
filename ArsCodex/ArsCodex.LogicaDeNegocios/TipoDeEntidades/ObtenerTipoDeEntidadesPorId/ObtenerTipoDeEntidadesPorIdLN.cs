using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.TipoDeEntidades.ObtenerTipoDeEntidadesPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.ObtenerTipoDeEntidadesPorId;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.TipoDeEntidades.ObtenerTipoDeEntidades;

namespace ArsCodex.LogicaDeNegocios.TipoDeEntidades.ObtenerTipoDeEntidadesPorId
{
    public class ObtenerTipoDeEntidadesPorIdLN : IObtenerTipoDeEntidadesPorIdLN
    {
        private readonly IObtenerTipoDeEntidadesPorIdAD _obtenerTipoDeEntidadesPorIdLN;

        public ObtenerTipoDeEntidadesPorIdLN()
        {
            _obtenerTipoDeEntidadesPorIdLN = new ObtenerTipoDeEntidadesPorIdAD();
        }
        public TipoDeEntidadesDto Obtener(int id)
        { 
            TipoDeEntidadesDto tipoDeEntidadesDto = _obtenerTipoDeEntidadesPorIdLN.Obtener(id);
            return tipoDeEntidadesDto;

        }
    }
}
