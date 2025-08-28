using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.ModuloAlertas.EditarModuloAlertas
{
    public interface IEditarModuloAlertasAD
    {
        Task<ModuloAlertasDto> ObtenerPorReservaAsync(int idReservaLiquidez);
        Task<int> EditarAlertaAsync(ModuloAlertasDto alerta);
    }
}
