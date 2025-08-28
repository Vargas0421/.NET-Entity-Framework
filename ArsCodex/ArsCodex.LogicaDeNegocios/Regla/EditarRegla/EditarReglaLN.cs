using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.Regla.EditarRegla;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.EditarRegla;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Regla.EditarRegla;
using ArsCodex.AccesoADatos.Regla.ObtenerReglaPorId;

namespace ArsCodex.LogicaDeNegocios.Regla.EditarRegla
{
    public class EditarReglaLN : IEditarReglaLN
    {
        private readonly IEditarReglaAD _editarReglaAD;
        public EditarReglaLN()
        {
            _editarReglaAD = new EditarReglaAD();
        }
        public int Editar(ReglaDto LaReglaParaGuardar)
        {
            return _editarReglaAD.Editar(LaReglaParaGuardar);
        }
    }
}
