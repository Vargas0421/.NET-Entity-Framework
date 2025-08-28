using ArsCodex.Abstracciones.AccesoADatos.ModuloAlertas.ListarModuloAlertas;
using ArsCodex.Abstracciones.LogicasDeNegocios.ModuloAlertas.ListarModuloAlertas;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.ModuloAlertas.ListarModuloAlertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.ModuloAlertas.ListarModuloAlertas
{
    public class ListarModuloAlertasLN : IListarModuloAlertasLN
    {
        private readonly IListarModuloAlertasAD _listarModuloAlertasAD;

        public ListarModuloAlertasLN()
        {
            _listarModuloAlertasAD = new ListarModuloAlertasAD();
        }   

        public List<ModuloAlertasDto> ListarAlertas()
        {
            List<ModuloAlertasDto> listaDeModuloAlertas = _listarModuloAlertasAD.ListarAlertas();
            return listaDeModuloAlertas;
        }
    }
}
