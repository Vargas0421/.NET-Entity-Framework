using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.ReservaDeLiquidez.EditarReservaDeLiquidez
{
    public interface IEditarReservaDeLiquidezAD
    {
        Task<int> EditarReservaDeLiquidez(ReservaDeLiquidezDto laReservaAEditar);
    }
}
