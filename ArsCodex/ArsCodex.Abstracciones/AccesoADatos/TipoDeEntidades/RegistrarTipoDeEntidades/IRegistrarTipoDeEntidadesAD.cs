using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.ModelosParaUI;

namespace ArsCodex.Abstracciones.AccesoADatos.TipoDeEntidades.RegistrarTipoDeEntidades
{
    public interface IRegistrarTipoDeEntidadesAD
    {
        Task<int> Registrar(TipoDeEntidadesDto ElTipoDeEntidadParaGuardar);

    }
}
