using ArsCodex.Abstracciones.AccesoADatos.ModuloAlertas.RegistrarModuloAlertas;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.ModuloAlertas.RegistrarModuloAlertas
{
    public class RegistrarModuloAlertasAD : IRegistrarModuloAlertasAD
    {
        private readonly Contexto _contexto;

        public RegistrarModuloAlertasAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> RegistrarAlerta(ModuloAlertasDto alertaARegistrar)
        {
            var alerta = new ModuloAlertasAD
            {
                IdEntidad = alertaARegistrar.IdEntidad,
                IdContador = alertaARegistrar.IdContador, 
                Periodo = alertaARegistrar.Periodo,
                CantidadDeReglasIncumplidas = alertaARegistrar.CantidadDeReglasIncumplidas,
                IdReservaLiquidez = alertaARegistrar.IdReservaLiquidez,
                FechaDeRegistro = alertaARegistrar.FechaDeRegistro == default
                                               ? DateTime.Now
                                               : alertaARegistrar.FechaDeRegistro,
                FechaDeModificacion = alertaARegistrar.FechaDeModificacion == default
                                               ? DateTime.Now
                                               : alertaARegistrar.FechaDeModificacion,
                Estado = alertaARegistrar.Estado
            };

            _contexto.ModuloAlertas.Add(alerta);
            return await _contexto.SaveChangesAsync();
        }
    }
}
