using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.TipoDeEntidades.RegistrarTipoDeEntidades;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;

namespace ArsCodex.AccesoADatos.TipoDeEntidades.RegistrarTipoDeEntidades
{
    public class RegistrarTipoDeEntidadesAD : IRegistrarTipoDeEntidadesAD
    {
        private readonly Contexto _contexto;

        public RegistrarTipoDeEntidadesAD()
        {
            _contexto = new Contexto();
        }
        public async Task<int> Registrar(TipoDeEntidadesDto ElTipoDeEntidadParaGuardar) 
        {
            TipoDeEntidadesAD ElTipoDeEntidadesAGuardar = ConvertirObjeto(ElTipoDeEntidadParaGuardar);
            _contexto.TipoDeEntidades.Add(ElTipoDeEntidadesAGuardar);
            int cantidadDeDatosAlmacenados = await _contexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
        private TipoDeEntidadesAD ConvertirObjeto(TipoDeEntidadesDto ElTipoDeEntidadParaGuardar)
        {
            return new TipoDeEntidadesAD
            {
                nombreTipoEntidad = ElTipoDeEntidadParaGuardar.NombreTipoEntidad,
                descripcion = ElTipoDeEntidadParaGuardar.Descripcion,
                fechaDeRegistro = DateTime.Now,
                estado = true
            };
        }
    }
}
