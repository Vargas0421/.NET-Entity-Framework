using ArsCodex.Abstracciones.AccesoADatos.ReservaDeLiquidez.ListarReservaDeLiquidez;
using ArsCodex.Abstracciones.LogicasDeNegocios.ReservaDeLiquidez.ListarReservaDeLiquidez;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.ReservaDeLiquidez.ListarReservaDeLiquidez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.ReservaDeLiquidez.ListarReservaDeLiquidez
{
    public class ListarReservaDeLiquidezLN : IListarReservaDeLiquidezLN
    {
        private readonly IListarReservaDeLiquidezAD _listarReservaDeLiquidezAD;

        public ListarReservaDeLiquidezLN()
        {
            _listarReservaDeLiquidezAD = new ListarReservaDeLiquidezAD();
        }

        public List<ReservaDeLiquidezDto> ListarReservaDeLiquidez()
        {
            List<ReservaDeLiquidezDto> listaDeReservaDeLiquidez = _listarReservaDeLiquidezAD.Listar();
            return listaDeReservaDeLiquidez;
        }
    }
}
