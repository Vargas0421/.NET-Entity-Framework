using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.ModelosParaUI;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.Regla.ListarRegla
{
    public interface IListarReglaLN
    {
        List<ReglaDto> Listar(int idTipoEntidad);
    }
}
