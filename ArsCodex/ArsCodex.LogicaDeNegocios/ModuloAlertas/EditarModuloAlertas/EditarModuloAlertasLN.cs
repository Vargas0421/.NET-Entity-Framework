using ArsCodex.Abstracciones.AccesoADatos.ModuloAlertas.EditarModuloAlertas;
using ArsCodex.Abstracciones.LogicasDeNegocios.ModuloAlertas.EditarModuloAlertas;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.ModuloAlertas.EditarModuloAlertas;
using ArsCodex.AccesoADatos.ModuloAlertas.RegistrarModuloAlertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.ModuloAlertas.EditarModuloAlertas
{
    public class EditarModuloAlertasLN : IEditarModuloAlertasLN
    {
        private readonly IEditarModuloAlertasAD _editarAD;
        private readonly RegistrarModuloAlertasAD _registrarAD;

        public EditarModuloAlertasLN()
        {
            _editarAD = new EditarModuloAlertasAD();
            _registrarAD = new RegistrarModuloAlertasAD();
        }

        public async Task CrearOActualizarAlertaAsync(ModuloAlertasDto dto)
        {
            var existente = await _editarAD.ObtenerPorReservaAsync(dto.IdReservaLiquidez);

            if (existente != null)
            {
                dto.IdAlerta = existente.IdAlerta;
                await _editarAD.EditarAlertaAsync(dto);
            }
            else if (dto.CantidadDeReglasIncumplidas > 0)
            {
             
                await _registrarAD.RegistrarAlerta(dto);
            }
           
        }
    }
}
