using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.ListarBitacora
{
    public interface IListarBitacoraLN
    {
        List<BitacoraDto> Listar();
    }
}
