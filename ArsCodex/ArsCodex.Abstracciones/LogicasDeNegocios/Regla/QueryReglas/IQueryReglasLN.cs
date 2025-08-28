using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.Regla.QueryReglas
{
    public interface IQueryReglasLN
    {
        Task<List<string>> Evaluar(ReservaDeLiquidezDto dto, int idTipoEntidad);
    }
}
