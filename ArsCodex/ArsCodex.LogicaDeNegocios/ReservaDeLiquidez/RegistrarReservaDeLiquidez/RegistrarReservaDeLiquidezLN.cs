using ArsCodex.Abstracciones.AccesoADatos.ReservaDeLiquidez.RegistrarReservaDeLiquidez;
using ArsCodex.Abstracciones.Comunes.Fecha;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.QueryReglas;
using ArsCodex.Abstracciones.LogicasDeNegocios.ReservaDeLiquidez.RegistrarReservaDeLiquidezLN;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.ReservaDeLiquidez.RegistrarReservaDeLiquidez;
using ArsCodex.LogicaDeNegocios.Comunes.Fecha;
using ArsCodex.LogicaDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.LogicaDeNegocios.Regla.QueryReglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.ReservaDeLiquidez.RegistrarReservaDeLiquidez
{
    public class RegistrarReservaDeLiquidezLN : IRegistrarReservaDeLiquidezLN
    {
        private IRegistrarReservaDeLiquidezAD _registrarReservaDeLiquidezAD;
        private readonly IQueryReglasLN _reglaLN;
        private readonly IFechaLN _fecha;
        private readonly IObtenerEntidadPorIdLN _entidad;
        int zonaHoraria = 0;

        public RegistrarReservaDeLiquidezLN()
        {
            _registrarReservaDeLiquidezAD = new RegistrarReservaDeLiquidezAD();
            _fecha = new FechaLN();
            _reglaLN = new QueryReglasLN();
            _entidad = new ObtenerEntidadPorIdLN();
            zonaHoraria = -6;
        }
        public async Task<int> RegistrarReservaDeLiquidez(ReservaDeLiquidezDto laReservaARegistrar)
        {
            laReservaARegistrar.FechaDeRegistro = _fecha.ObtenerFechaPorZonaHoraria(zonaHoraria);

            var reglasIncumplidas = await _reglaLN.Evaluar(laReservaARegistrar, _entidad.Obtener(laReservaARegistrar.IdEntidad).idTipoEntidad);
            if (reglasIncumplidas.Any())
            {
                laReservaARegistrar.Estado = 2;
                string popup = string.Join("\\n", reglasIncumplidas.Select(n =>
            $"Estimado usuario, la regla ({n}) no se cumplió favor verificar."));
            }
            else
            {
                laReservaARegistrar.Estado = 1;
            }

                 
            int cantidadDeFilasAfectadas = await _registrarReservaDeLiquidezAD.RegistrarReservaDeLiquidez(laReservaARegistrar);
            return cantidadDeFilasAfectadas;
        }
    }
}
