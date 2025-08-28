using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.TipoDeEntidades.RegistrarTipoDeEntidades;
using ArsCodex.Abstracciones.Comunes.Fecha;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.RegistrarTipoDeEntidades;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.TipoDeEntidades.RegistrarTipoDeEntidades;
using ArsCodex.LogicaDeNegocios.Comunes.Fecha;

namespace ArsCodex.LogicaDeNegocios.TipoDeEntidades.RegistrarTipoDeEntidades
{
    public class RegistrarTipoDeEntidadesLN : IRegistrarTipoDeEntidadesLN
    {
        private readonly IRegistrarTipoDeEntidadesAD _registrarTipoDeEntidadesAD;
        private readonly IFechaLN _fechaLN;
        int zonaHoraria = 0;

        public RegistrarTipoDeEntidadesLN()
        {
            _registrarTipoDeEntidadesAD = new RegistrarTipoDeEntidadesAD();
            _fechaLN = new FechaLN();
            zonaHoraria = Convert.ToInt32(ConfigurationManager.AppSettings["ZonaHoraria"]);
        }
        public async Task<int> Registrar(TipoDeEntidadesDto ElTipoDeEntidadesParaGuardar)
        {
            ElTipoDeEntidadesParaGuardar.FechaDeRegistro = _fechaLN.ObtenerFechaPorZonaHoraria(zonaHoraria);
            ElTipoDeEntidadesParaGuardar.Estado = true;
            int cantidadDeDatosAlmacenados = await _registrarTipoDeEntidadesAD.Registrar(ElTipoDeEntidadesParaGuardar);
            return cantidadDeDatosAlmacenados;
        }
    }
}
