using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.Regla.RegistrarRegla;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;

namespace ArsCodex.AccesoADatos.Regla.RegistrarRegla
{
    public class RegistrarReglaAD : IRegistrarReglaAD
    {
        private readonly Contexto _contexto;

        public RegistrarReglaAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> Registrar(ReglaDto reglaParaGuardar)
        {
            ReglaAD reglaAD = ConvertirObjeto(reglaParaGuardar);
            _contexto.Reglas.Add(reglaAD);
            int cantidadDeDatosAlmacenados = await _contexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
        private ReglaAD ConvertirObjeto(ReglaDto reglaParaGuardar)
        {
            return new ReglaAD
            {
                Nombre = reglaParaGuardar.Nombre,
                Descripcion = reglaParaGuardar.Descripcion,
                Valor = reglaParaGuardar.Valor,
                TipoDeAccion = reglaParaGuardar.TipoDeAccion,
                IdTipoEntidad = reglaParaGuardar.IdTipoEntidad,
                FechaDeRegistro = DateTime.Now,
                Estado = true
            };
        }
    }
}
