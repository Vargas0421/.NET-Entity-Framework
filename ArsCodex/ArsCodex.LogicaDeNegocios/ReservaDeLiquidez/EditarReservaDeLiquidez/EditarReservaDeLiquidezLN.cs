using ArsCodex.Abstracciones.AccesoADatos.ReservaDeLiquidez.EditarReservaDeLiquidez;
using ArsCodex.Abstracciones.Comunes.Fecha;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.QueryReglas;
using ArsCodex.Abstracciones.LogicasDeNegocios.ReservaDeLiquidez.EditarReservaDeLiquidez;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.ReservaDeLiquidez.EditarReservaDeLiquidez;
using ArsCodex.LogicaDeNegocios.Comunes.Fecha;
using ArsCodex.LogicaDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.LogicaDeNegocios.Regla.QueryReglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.ReservaDeLiquidez.EditarReservaDeLiquidez
{
    public class EditarReservaDeLiquidezLN : IEditarReservaDeLiquidezLN
    {
        private readonly IEditarReservaDeLiquidezAD _editarReservaAD;
        private readonly IQueryReglasLN _reglaLN;
        private readonly IFechaLN _fecha;
        private readonly IObtenerEntidadPorIdLN _entidadLN;
        private readonly int _zonaHoraria = -6;

        public EditarReservaDeLiquidezLN()
        {
            _editarReservaAD = new EditarReservaDeLiquidezAD();
            _reglaLN = new QueryReglasLN();
            _fecha = new FechaLN();
            _entidadLN = new ObtenerEntidadPorIdLN();
        }

        public async Task<int> EditarReservaDeLiquidez(ReservaDeLiquidezDto reserva)
        {
            
            reserva.FechaDeModificacion = _fecha.ObtenerFechaPorZonaHoraria(_zonaHoraria);

            // Evaluar reglas activas para esta entidad
            var tipoEntidad = _entidadLN.Obtener(reserva.IdEntidad).idTipoEntidad;
            var reglasIncumplidas = await _reglaLN.Evaluar(reserva, tipoEntidad);
            if (reglasIncumplidas.Any())
            {
                reserva.Estado = 2; // Estado de regla incumplida
                string popup = string.Join("\\n", reglasIncumplidas.Select(n =>
            $"Estimado usuario, la regla ({n}) no se cumplió favor verificar."));
            }else
            {
                reserva.Estado = 3;
            }

            int cantidadDeFilasAfectadas = await _editarReservaAD.EditarReservaDeLiquidez(reserva);
            return cantidadDeFilasAfectadas;
        }
    }
}
