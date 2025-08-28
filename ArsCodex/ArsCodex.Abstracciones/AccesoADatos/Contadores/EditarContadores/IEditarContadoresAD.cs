using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.Contadores.EditarContadores
{
    public interface IEditarContadoresAD
    {
        int EditarContadores(ContadoresDto elContadorParaEditar);

    }
}
