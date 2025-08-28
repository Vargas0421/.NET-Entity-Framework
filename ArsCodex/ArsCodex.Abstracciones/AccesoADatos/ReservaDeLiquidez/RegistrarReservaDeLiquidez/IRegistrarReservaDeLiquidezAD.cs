using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.ReservaDeLiquidez.RegistrarReservaDeLiquidez
{
    public interface IRegistrarReservaDeLiquidezAD
    {
        Task<int> RegistrarReservaDeLiquidez(ReservaDeLiquidezDto laReservaARegistrar);
        Task<bool> ExisteReservaParaPeriodo(int idEntidad, DateTime periodo);
        Task<List<string>> ObtenerReglasActivas();
    }
}
