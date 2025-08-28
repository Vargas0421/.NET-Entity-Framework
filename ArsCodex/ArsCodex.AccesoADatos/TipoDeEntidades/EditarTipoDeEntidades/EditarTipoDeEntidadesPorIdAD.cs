using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.TipoDeEntidades.EditarTiposDeEntidades;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;

namespace ArsCodex.AccesoADatos.TipoDeEntidades.EditarTipoDeEntidades
{
    public class EditarTipoDeEntidadesPorIdAD : IEditarTipoDeEntidadesAD
    {
        private Contexto _contexto;
        public EditarTipoDeEntidadesPorIdAD()
        {
            _contexto = new Contexto();
        }
        
        public int Editar(TipoDeEntidadesDto ElTipoDeEntidadParaGuardar)
        {
            int cantidadDeDatosAlmacenados = 0;
            TipoDeEntidadesAD ElTipoDeEntidadEnLaBd = _contexto.TipoDeEntidades.Where(tipoDeEntidades => tipoDeEntidades.idTipoEntidad == ElTipoDeEntidadParaGuardar.IdTipoEntidad).FirstOrDefault();
            if (ElTipoDeEntidadEnLaBd != null) 
            {
                ElTipoDeEntidadEnLaBd.nombreTipoEntidad = ElTipoDeEntidadParaGuardar.NombreTipoEntidad;
                ElTipoDeEntidadEnLaBd.descripcion = ElTipoDeEntidadParaGuardar.Descripcion;
                ElTipoDeEntidadEnLaBd.fechaDeModificacion = ElTipoDeEntidadEnLaBd.fechaDeModificacion ?? DateTime.Now;
                ElTipoDeEntidadEnLaBd.estado = ElTipoDeEntidadParaGuardar.Estado;
                cantidadDeDatosAlmacenados = _contexto.SaveChanges();
            }
            return cantidadDeDatosAlmacenados;
        }
    }
}
