using ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.ObtenerContadoresPorId;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Contadores.ObtenerContadoresPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Contadores.ObtenerContadoresPorId
{
    public class ObtenerContadoresPorIdLN : IObtenerContadoresPorIdLN
    {
        private readonly ObtenerContadoresPorIdAD _obtenerContadoresPorIdAD;
        
        public ObtenerContadoresPorIdLN()
        {
            _obtenerContadoresPorIdAD = new ObtenerContadoresPorIdAD();
        }

        public ContadoresDto obtenerContadorPorId( int idContador)
        {
            ContadoresDto contador = _obtenerContadoresPorIdAD.ObtenerContadorPorId(idContador);
            return contador;
        }
    }
}
