using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.TipoDeEntidades.EditarTiposDeEntidades;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.EditarTiposDeEntidades;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.TipoDeEntidades.EditarTipoDeEntidades;

namespace ArsCodex.LogicaDeNegocios.TipoDeEntidades.EditarTipoDeEntidades
{
    public class EditarTipoDeEntidadesLN : IEditarTipoDeEntidadesLN
    {
        private readonly IEditarTipoDeEntidadesAD _editarTipoDeEntidadesAD;
        
        public EditarTipoDeEntidadesLN( )
        {
            _editarTipoDeEntidadesAD = new EditarTipoDeEntidadesPorIdAD();
        }
        public int Editar(TipoDeEntidadesDto ElTipoDeEntidadesParaGuardar)
        {
            return _editarTipoDeEntidadesAD.Editar(ElTipoDeEntidadesParaGuardar);
        }
    }
}
