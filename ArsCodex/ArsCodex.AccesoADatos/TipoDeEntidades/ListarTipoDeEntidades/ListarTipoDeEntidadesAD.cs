using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.TipoDeEntidades.ListarTipoDeEntidades;
using ArsCodex.Abstracciones.ModelosParaUI;

namespace ArsCodex.AccesoADatos.Modelos.ListarTipoDeEntidades
{
    public class ListarTipoDeEntidadesAD : IListarTipoDeEntidadesAD
    {
        private Contexto _contexto;
        public ListarTipoDeEntidadesAD()
        {
            _contexto = new Contexto();
        }
        public List<TipoDeEntidadesDto> Listar()
        {
      
            List<TipoDeEntidadesAD> TipoDeEntidadesADS = _contexto.TipoDeEntidades.ToList();
            List<TipoDeEntidadesDto> LaListaDeTipoDeEntidades = (from TipoDeEntidades in TipoDeEntidadesADS
                                                                 select new TipoDeEntidadesDto
                                                                 {
                                                                     IdTipoEntidad = TipoDeEntidades.idTipoEntidad,
                                                                     NombreTipoEntidad = TipoDeEntidades.nombreTipoEntidad,
                                                                     Descripcion = TipoDeEntidades.descripcion,
                                                                     FechaDeRegistro = TipoDeEntidades.fechaDeRegistro,
                                                                     Estado = TipoDeEntidades.estado
                                                                 }).ToList();
            return LaListaDeTipoDeEntidades;
        }
    }
}
