using ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.ListarBitacora;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Bitacora.ListarBitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Bitacora.ListarBitacora
{
    public class ListarBitacoraLN : IListarBitacoraLN
    {
        private readonly ListarBitacoraAD _listarBitacoraAD;

        public ListarBitacoraLN()
        {
            _listarBitacoraAD = new ListarBitacoraAD();
        }
        public List<BitacoraDto> Listar()
        {
            List<BitacoraDto> listaDeBitacora = _listarBitacoraAD.Listar();
            return listaDeBitacora;
        }
    }
}
