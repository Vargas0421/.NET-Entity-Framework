using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.AccesoADatos.Entidad.RegistrarEntidad
{
    public interface IRegistrarEntidadAD
    {
        Task<int> Registrar(EntidadDto elCursoParaGuardar);
    }
}
