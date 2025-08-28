using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.ModelosParaUI;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.ListarTipoDeEntidades
{
    public interface IListarTipoDeEntidadesLN
    {
        List<TipoDeEntidadesDto> Listar();
    }
}
