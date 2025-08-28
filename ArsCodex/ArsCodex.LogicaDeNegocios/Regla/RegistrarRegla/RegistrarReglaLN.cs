using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.Regla.RegistrarRegla;
using ArsCodex.Abstracciones.Comunes.Fecha;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.RegistrarRegla;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Regla.RegistrarRegla;
using ArsCodex.LogicaDeNegocios.Comunes.Fecha;

namespace ArsCodex.LogicaDeNegocios.Regla.RegistrarRegla
{
    public class RegistrarReglaLN : IRegistrarReglaLN
    {
        private readonly IRegistrarReglaAD _registrarReglaAD;
        private readonly IFechaLN _fechaLN;
        int zonaHoraria = 0;
        public RegistrarReglaLN()
        {
            _registrarReglaAD = new RegistrarReglaAD();
            _fechaLN = new FechaLN();
            zonaHoraria = Convert.ToInt32(ConfigurationManager.AppSettings["ZonaHoraria"]);
        }
        public async Task<int> Registrar(ReglaDto reglaParaGuardar)
        {
            reglaParaGuardar.FechaDeRegistro = _fechaLN.ObtenerFechaPorZonaHoraria(zonaHoraria);
            reglaParaGuardar.Estado = true;
            int cantidadDeDatosAlmacenados = await _registrarReglaAD.Registrar(reglaParaGuardar);
            return cantidadDeDatosAlmacenados;
        }
    }
}
