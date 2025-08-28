using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.ModuloAlertas.ListarModuloAlertas
{
    public interface IListarModuloAlertasAD
    {
        List<ModuloAlertasDto> ListarAlertas();
    }
}
