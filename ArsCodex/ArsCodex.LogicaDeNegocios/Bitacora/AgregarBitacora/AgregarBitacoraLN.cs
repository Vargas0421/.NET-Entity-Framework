using ArsCodex.Abstracciones.AccesoADatos.Bitacora.AgregarBitacora;
using ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Bitacora.AgregarBitacoraAD;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Bitacora.AgregarBitacora
{
    public class AgregarBitacoraLN : IAgregarBitacoraLN
    {
        private readonly IAgregarBitacoraAD _agregarBitacoraAD;

        public AgregarBitacoraLN()
        {
            _agregarBitacoraAD = new AgregarBitacoraAD();
        }

        public void Ejecutar(string tabla, string tipoEvento, object datosAnteriores = null, object datosPosteriores = null, Exception ex = null)
        {
            var dto = new BitacoraDto
            {
                TablaDeEvento = tabla,
                TipoDeEvento = tipoEvento,
                FechaDeEvento = DateTime.Now,
                DescripcionDeEvento = ex?.Message ?? $"Evento {tipoEvento} sobre tabla {tabla}.",
                StackTrace = ex?.StackTrace ?? string.Empty,
                DatosAnteriores = datosAnteriores != null ? JsonSerializer.Serialize(datosAnteriores) : null,
                DatosPosteriores = datosPosteriores != null ? JsonSerializer.Serialize(datosPosteriores) : null
            };

            _agregarBitacoraAD.Ejecutar(dto);
        }
    }
}
