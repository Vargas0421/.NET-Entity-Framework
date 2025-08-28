using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.ListarTipoDeEntidades;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos.ListarTipoDeEntidades;

namespace ArsCodex.LogicaDeNegocios.TipoDeEntidades.ListarTipoDeEntidades
{
    public class ListarTipoDeEntidadesLN : IListarTipoDeEntidadesLN
    {
        private readonly ListarTipoDeEntidadesAD _listarTipoDeEntidadesAD;

        public ListarTipoDeEntidadesLN( )
        {
            _listarTipoDeEntidadesAD =  new ListarTipoDeEntidadesAD();
        }
        public List<TipoDeEntidadesDto> Listar()
        {
            List<TipoDeEntidadesDto> listaDeTipoDeEntidades = _listarTipoDeEntidadesAD.Listar();
            return listaDeTipoDeEntidades;
        }
    }
}
