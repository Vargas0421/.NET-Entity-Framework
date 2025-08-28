using ArsCodex.Abstracciones.AccesoADatos.ModuloAlertas.EditarModuloAlertas;
using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.ModuloAlertas.EditarModuloAlertas
{
    public class EditarModuloAlertasAD : IEditarModuloAlertasAD
    {
        private readonly Contexto _contexto;
        public EditarModuloAlertasAD() => _contexto = new Contexto();

        public async Task<ModuloAlertasDto> ObtenerPorReservaAsync(int idReservaLiquidez)
        {
            var e = await _contexto.ModuloAlertas
                .FirstOrDefaultAsync(a => a.IdReservaLiquidez == idReservaLiquidez);
            if (e == null) return null;

            return new ModuloAlertasDto
            {
                IdAlerta = e.IdAlerta,
                IdEntidad = e.IdEntidad,
                IdContador = e.IdContador,
                Periodo = e.Periodo,
                CantidadDeReglasIncumplidas = e.CantidadDeReglasIncumplidas,
                IdReservaLiquidez = e.IdReservaLiquidez,
                FechaDeRegistro = e.FechaDeRegistro,
                FechaDeModificacion = e.FechaDeModificacion,
                Estado = e.Estado
            };
        }

        public async Task<int> EditarAlertaAsync(ModuloAlertasDto dto)
        {
            var e = await _contexto.ModuloAlertas
                .FirstOrDefaultAsync(a => a.IdAlerta == dto.IdAlerta);
            if (e == null)
                throw new InvalidOperationException("Alerta no encontrada para editar.");

            e.CantidadDeReglasIncumplidas = dto.CantidadDeReglasIncumplidas;
            e.FechaDeModificacion = dto.FechaDeModificacion;
            e.Estado = dto.Estado;

            return await _contexto.SaveChangesAsync();
        }
    }
}
