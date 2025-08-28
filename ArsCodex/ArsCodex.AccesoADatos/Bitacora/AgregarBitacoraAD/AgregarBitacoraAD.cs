using ArsCodex.Abstracciones.AccesoADatos.Bitacora.AgregarBitacora;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Bitacora.AgregarBitacoraAD
{
    public class AgregarBitacoraAD : IAgregarBitacoraAD
    {
        private readonly Contexto _contexto;

        public AgregarBitacoraAD()
        {
            _contexto = new Contexto();
        }

        public void Ejecutar(BitacoraDto dto)
        {
            var entidad = new BitacoraAD
            {
                tablaDeEvento = dto.TablaDeEvento,
                tipoDeEvento = dto.TipoDeEvento,
                fechaDeEvento = dto.FechaDeEvento,
                descripcionDeEvento = dto.DescripcionDeEvento,
                stackTrace = dto.StackTrace,
                datosAnteriores = dto.DatosAnteriores,
                datosPosteriores = dto.DatosPosteriores
            };

            _contexto.Bitacoras.Add(entidad);
            _contexto.SaveChanges();
        }
    }
    
}
