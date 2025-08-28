using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.LogicasDeNegocios.ModuloAlertas.RegistrarModuloAlertas
{
    public interface IRegistrarModuloAlertasLN
    {
        Task<int> RegistrarAlerta(ModuloAlertasDto alerta);
    }
}
