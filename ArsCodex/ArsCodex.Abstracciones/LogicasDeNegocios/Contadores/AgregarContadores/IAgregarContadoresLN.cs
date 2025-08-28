using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.AgregarContadores
{
    public interface IAgregarContadoresLN
    {
         Task<int> AgregarContadores(ContadoresDto elContadorAAgregarDto);
    }
}
