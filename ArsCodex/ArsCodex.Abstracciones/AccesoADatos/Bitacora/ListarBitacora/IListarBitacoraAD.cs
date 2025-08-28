using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.Bitacora.ListarBitacora
{
    public interface IListarBitacoraAD
    {
        List<BitacoraDto> Listar();
    }
}
