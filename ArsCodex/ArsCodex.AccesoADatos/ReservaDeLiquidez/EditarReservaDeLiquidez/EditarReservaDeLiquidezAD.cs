using ArsCodex.Abstracciones.AccesoADatos.ReservaDeLiquidez.EditarReservaDeLiquidez;
using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.ReservaDeLiquidez.EditarReservaDeLiquidez
{
    public class EditarReservaDeLiquidezAD : IEditarReservaDeLiquidezAD
    {
        private readonly Contexto _contexto;

        public EditarReservaDeLiquidezAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> EditarReservaDeLiquidez(ReservaDeLiquidezDto laReservaAEditar)
        {
            int cantidadDeDatosAlmacenados = 0;
            var entidad = await _contexto.ReservaDeLiquidez
                                .FirstOrDefaultAsync(r => r.idReservaLiquidez == laReservaAEditar.IdReservaLiquidez);
            if (entidad == null)
                throw new InvalidOperationException("Reserva de liquidez no encontrada.");

            entidad.montoDeReserva = laReservaAEditar.MontoDeReserva;
            entidad.cantidadDeBeneficiarios = laReservaAEditar.CantidadDeBeneficiarios;
            entidad.montoDeSeguroBancario = laReservaAEditar.MontoDeSeguroBancario;
            entidad.fechaDeModificacion = laReservaAEditar.FechaDeModificacion;
            entidad.estado = laReservaAEditar.Estado;
            cantidadDeDatosAlmacenados = _contexto.SaveChanges();

            return cantidadDeDatosAlmacenados;
        }
    }
}
