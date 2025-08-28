using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.AgregarBitacora
{
    public interface IAgregarBitacoraLN
    {
        void Ejecutar(string tabla, string tipoEvento, object datosAnteriores = null, object datosPosteriores = null, Exception ex = null);
    }
}
