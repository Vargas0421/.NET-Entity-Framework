using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.Regla.ListarRegla;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.ListarRegla;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Regla.ListarRegla;

namespace ArsCodex.LogicaDeNegocios.Regla.ListarRegla
{
    public class ListarReglaLN : IListarReglaLN
    {
        private readonly IListarReglaAD _listarReglaAD;
        public ListarReglaLN()
        {
            _listarReglaAD = new ListarReglaAD();
        }
        public List<ReglaDto> Listar(int idTipoEntidad)
        {
           List<ReglaDto> listaDeReglas = _listarReglaAD.Listar(idTipoEntidad);
            return listaDeReglas;
        }
    }
}
