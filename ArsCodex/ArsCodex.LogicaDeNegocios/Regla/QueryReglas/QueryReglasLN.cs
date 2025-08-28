using ArsCodex.Abstracciones.AccesoADatos.Regla.QueryReglas;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.QueryReglas;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Regla.QueryReglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Regla.QueryReglas
{
    public class QueryReglasLN : IQueryReglasLN
    {
        private readonly IQueryReglasAD _reglaQueryAD;

        public QueryReglasLN()
        {
            _reglaQueryAD = new QueryReglasAD();
        }

        public async Task<List<string>> Evaluar(ReservaDeLiquidezDto dto, int idTipoEntidad)
        {
            var reglas = await _reglaQueryAD.ObtenerReglasActivasPorTipoEntidad(idTipoEntidad);
            var incumplidas = new List<string>();

            foreach (var r in reglas)
            {
                if (!TryGetValorCampo(dto, r.Nombre, out decimal valorCampo))
                    continue;

                bool cumple;
                switch (r.TipoDeAccion)
                {
                    case 1: // mínimo
                        cumple = valorCampo >= r.Valor;
                        break;
                    case 2: // máximo
                        cumple = valorCampo <= r.Valor;
                        break;
                    default:
                        cumple = true;
                        break;
                }

                if (!cumple)
                    incumplidas.Add(r.Nombre);
            }

            return incumplidas;
        }

        private bool TryGetValorCampo(ReservaDeLiquidezDto dto, string nombreRegla, out decimal valor)
        {
            valor = 0;
            switch (nombreRegla)
            {
                case "MontoDeReserva": valor = dto.MontoDeReserva; return true;
                case "MontoDeSeguroBancario": valor = dto.MontoDeSeguroBancario; return true;
                case "CantidadDeBeneficiarios": valor = dto.CantidadDeBeneficiarios; return true;
                default: return false;
            }
        }
    }
}
