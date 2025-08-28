using ArsCodex.Abstracciones.AccesoADatos.Contadores.EditarContadores;
using ArsCodex.Abstracciones.Comunes.Fecha;
using ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.EditarContadores;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Contadores.EditarContadores;
using ArsCodex.LogicaDeNegocios.Comunes.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Contadores.EditarContadores
{
    public class EditarContadoresLN : IEditarContadoresLN
    {
        private readonly IEditarContadoresAD _editarContadoresAD;
        private readonly IFechaLN _fecha;
        int zonaHoraria = 0; // Zona horaria UTC-3, ajustar según sea necesario 

        public EditarContadoresLN()
        {
            _editarContadoresAD = new EditarContadoresAD();
            _fecha = new FechaLN();
            zonaHoraria = -6;
        }   

        public int EditarContadores(ContadoresDto elContadorAEditar)
        {
            elContadorAEditar.FechaDeModificacion = _fecha.ObtenerFechaPorZonaHoraria(zonaHoraria);
            int cantidadDeFilasAfectadas = _editarContadoresAD.EditarContadores(elContadorAEditar);
            return cantidadDeFilasAfectadas;
        }
    }
}
