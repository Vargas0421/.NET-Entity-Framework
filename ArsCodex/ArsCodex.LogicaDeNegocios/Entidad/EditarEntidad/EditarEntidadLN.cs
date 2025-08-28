using ArsCodex.Abstracciones.AccesoADatos.Entidad.EditarEntidad;
using ArsCodex.Abstracciones.Comunes.Fecha;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.EditarEntidad;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Entidades.EditarEntidad;
using ArsCodex.LogicaDeNegocios.Comunes.Fecha;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Entidad.EditarEntidad
{
    public class EditarEntidadLN : IEditarEntidadLN
    {
        private readonly IEditarEntidadAD _EditarEntidadAD;
        private readonly IFechaLN _fecha;
        int zonaHoraria = 0;
        public EditarEntidadLN()
        {
            _EditarEntidadAD = new EditarEntidadAD();
            _fecha = new FechaLN();
            zonaHoraria = Convert.ToInt32(ConfigurationManager.AppSettings["ZonaHoraria"]);
        }

        public int Editar(EntidadDto elEntidadParaGuardar)
        {
            elEntidadParaGuardar.fechaDeModificacion = _fecha.ObtenerFechaPorZonaHoraria(zonaHoraria);
            elEntidadParaGuardar.estado = true;
            int cantidadDeDatosAlmacenados = _EditarEntidadAD.Editar(elEntidadParaGuardar);
            return cantidadDeDatosAlmacenados;
        }
    }
}
