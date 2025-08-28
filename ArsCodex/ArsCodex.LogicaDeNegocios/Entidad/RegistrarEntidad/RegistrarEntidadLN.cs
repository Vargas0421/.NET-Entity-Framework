using ArsCodex.Abstracciones.AccesoADatos.Entidad.RegistrarEntidad;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.RegistrarEntidad;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Entidades.RegistrarEntidad;
using ArsCodex.LogicaDeNegocios.Comunes.Fecha;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Entidad.RegistrarEntidad
{
    public class RegistrarEntidadLN : IRegistrarEntidadLN
    {
        private readonly IRegistrarEntidadAD _CrearEntidadAD;
        private readonly FechaLN _fecha;
        int zonaHoraria = 0;
        public RegistrarEntidadLN()
        {
            _CrearEntidadAD = new RegistrarEntidadAD();
            _fecha = new FechaLN();
            zonaHoraria = Convert.ToInt32(ConfigurationManager.AppSettings["ZonaHoraria"]);
        }

        public async Task<int> Registrar(EntidadDto elEntidadParaGuardar)
        {
            elEntidadParaGuardar.fechaDeRegistro = _fecha.ObtenerFechaPorZonaHoraria(zonaHoraria);
            elEntidadParaGuardar.estado = true;
            int cantidadDeDatosAlmacenados = await _CrearEntidadAD.Registrar(elEntidadParaGuardar);
            return cantidadDeDatosAlmacenados;
        }
    }
}
