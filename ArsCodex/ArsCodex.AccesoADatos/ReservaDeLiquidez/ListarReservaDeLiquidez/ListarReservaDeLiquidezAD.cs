using ArsCodex.Abstracciones.AccesoADatos.ReservaDeLiquidez.ListarReservaDeLiquidez;
using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.ReservaDeLiquidez.ListarReservaDeLiquidez
{
    public class ListarReservaDeLiquidezAD : IListarReservaDeLiquidezAD
    {
        private Contexto _contexto;
        public ListarReservaDeLiquidezAD()
        {
            _contexto = new Contexto();
        }
        public List<ReservaDeLiquidezDto> Listar()
        {
            List<ReservaDeLiquidezDto> laListaDeReservaDeLiquidez = (from ReservaDeLiquidez in _contexto.ReservaDeLiquidez
                                                                     select new ReservaDeLiquidezDto
                                                                     {
                                                                         IdReservaLiquidez = ReservaDeLiquidez.idReservaLiquidez,
                                                                         IdEntidad = ReservaDeLiquidez.idEntidad,
                                                                         MontoDeReserva = ReservaDeLiquidez.montoDeReserva,
                                                                         CantidadDeBeneficiarios = ReservaDeLiquidez.cantidadDeBeneficiarios,
                                                                         MontoDeSeguroBancario = ReservaDeLiquidez.montoDeSeguroBancario,
                                                                         Periodo = ReservaDeLiquidez.periodo,
                                                                         IdContador = ReservaDeLiquidez.idContador,
                                                                         FechaDeRegistro = ReservaDeLiquidez.fechaDeRegistro,
                                                                         FechaDeModificacion = ReservaDeLiquidez.fechaDeModificacion,
                                                                         Estado = ReservaDeLiquidez.estado
                                                                     }).ToList();
            return laListaDeReservaDeLiquidez;
        }
    }
}
