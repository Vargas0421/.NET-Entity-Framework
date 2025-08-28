using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.ReservaDeLiquidez.EditarReservaDeLiquidez
{
    public interface IEditarReservaDeLiquidezLN
    {
        Task<int> EditarReservaDeLiquidez(ReservaDeLiquidezDto reserva);
    }
}
