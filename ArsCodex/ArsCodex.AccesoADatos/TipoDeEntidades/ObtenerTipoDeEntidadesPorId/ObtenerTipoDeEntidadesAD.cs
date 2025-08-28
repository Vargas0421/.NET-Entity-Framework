using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.TipoDeEntidades.ObtenerTipoDeEntidadesPorId;
using ArsCodex.Abstracciones.ModelosParaUI;

namespace ArsCodex.AccesoADatos.TipoDeEntidades.ObtenerTipoDeEntidades
{
    public class ObtenerTipoDeEntidadesPorIdAD : IObtenerTipoDeEntidadesPorIdAD
    {
        private readonly Contexto _contexto;

        public ObtenerTipoDeEntidadesPorIdAD()
        {
            _contexto = new Contexto();
        }
        public TipoDeEntidadesDto Obtener(int id)
        {
            TipoDeEntidadesDto laListaDeTiposDeEntidades = (from tipoDeEntidades in _contexto.TipoDeEntidades
                                                            where tipoDeEntidades.idTipoEntidad == id
                                                            select new TipoDeEntidadesDto
                                                            {
                                                                IdTipoEntidad = tipoDeEntidades.idTipoEntidad,
                                                                NombreTipoEntidad = tipoDeEntidades.nombreTipoEntidad,
                                                                Descripcion = tipoDeEntidades.descripcion,
                                                                FechaDeRegistro = tipoDeEntidades.fechaDeRegistro,
                                                                FechaDeModificacion = tipoDeEntidades.fechaDeModificacion,
                                                                Estado = tipoDeEntidades.estado
                                                            }).FirstOrDefault();
            return (laListaDeTiposDeEntidades);

        }
    }
}
