using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.ListarContadores
{
    public interface IListarContadoresLN
    {
        List<ContadoresDto> ListarContadores();
    }
}
