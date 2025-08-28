using ArsCodex.Abstracciones.AccesoADatos.Entidad.ListarEntidad;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.ListarEntidad;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Entidades.ListarEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Entidad.ListarEntidad
{
    public class ListarEntidadLN : IListarEntidadLN
    {
        private readonly IListarEntidadAD _listarEntidadAD;
        //private readonly IFechaLN _fecha;
        //int zonaHoraria = 0;
        public ListarEntidadLN()
        {
            _listarEntidadAD = new ListarEntidadAD();
            //_fecha = new FechaLN();
            //zonaHoraria = Convert.ToInt32(ConfigurationManager.AppSettings["ZonaHoraria"]);
        }

        public List<EntidadDto> Listar()
        {
            List<EntidadDto> laEntidad = _listarEntidadAD.Listar();
            return laEntidad;
        }
    }
}
