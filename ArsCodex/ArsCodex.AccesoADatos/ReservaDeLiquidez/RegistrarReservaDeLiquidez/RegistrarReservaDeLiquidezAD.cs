using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.ReservaDeLiquidez.RegistrarReservaDeLiquidez;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;

namespace ArsCodex.AccesoADatos.ReservaDeLiquidez.RegistrarReservaDeLiquidez
{
    public class RegistrarReservaDeLiquidezAD : IRegistrarReservaDeLiquidezAD
    {
        private Contexto _contexto;

        public RegistrarReservaDeLiquidezAD()
        {
            _contexto = new Contexto();
        }
        public async Task<int> RegistrarReservaDeLiquidez(ReservaDeLiquidezDto laReservaARegistrar)
        {
            ReservaDeLiquidezAD laReservaARegistrarAD = ConvertirObjeto(laReservaARegistrar);
            _contexto.ReservaDeLiquidez.Add(laReservaARegistrarAD);
            int cantidadDeFilasAfectadas = await _contexto.SaveChangesAsync();
            return cantidadDeFilasAfectadas;

        }

        public async Task<bool> ExisteReservaParaPeriodo(int idEntidad, DateTime periodo)
        {
            return await _contexto.ReservaDeLiquidez
                .AnyAsync(r => r.idEntidad == idEntidad &&
                               r.periodo.Year == periodo.Year &&
                               r.periodo.Month == periodo.Month);
        }

        public async Task<List<string>> ObtenerReglasActivas()
        {
            // Ajusta al modelo real de tus reglas
            return await _contexto.Reglas
                .Where(r => r.Estado)
                .Select(r => r.Nombre) // o r.Expresion si la evalúas dinámicamente
                .ToListAsync();
        }


        private ReservaDeLiquidezAD ConvertirObjeto(ReservaDeLiquidezDto laReservaARegistrar)
        {
            return new ReservaDeLiquidezAD
            {
                idReservaLiquidez = laReservaARegistrar.IdReservaLiquidez,
                idEntidad = laReservaARegistrar.IdEntidad,
                montoDeReserva = laReservaARegistrar.MontoDeReserva,
                cantidadDeBeneficiarios = laReservaARegistrar.CantidadDeBeneficiarios,
                montoDeSeguroBancario = laReservaARegistrar.MontoDeSeguroBancario,
                periodo = laReservaARegistrar.Periodo,
                idContador = laReservaARegistrar.IdContador,
                fechaDeRegistro = laReservaARegistrar.FechaDeRegistro == default ? DateTime.Now : laReservaARegistrar.FechaDeRegistro,
                fechaDeModificacion = laReservaARegistrar.FechaDeModificacion == default ? DateTime.Now : laReservaARegistrar.FechaDeModificacion,
                estado = laReservaARegistrar.Estado
            };
        }
    }
}
