using ArsCodex.Abstracciones.AccesoADatos.Regla.QueryReglas;
using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Regla.QueryReglas
{
    public class QueryReglasAD : IQueryReglasAD
    {
        private Contexto _contexto;
        public QueryReglasAD()
        {
            _contexto = new Contexto();
        }

        public async Task<List<ReglaDto>> ObtenerReglasActivasPorTipoEntidad(int idTipoEntidad)
        {
            return await _contexto.Reglas
                .Where(r => r.Estado && r.IdTipoEntidad == idTipoEntidad)
                .Select(r => new ReglaDto
                {
                    IdRegla = r.IdRegla,
                    Nombre = r.Nombre,
                    Descripcion = r.Descripcion,
                    Valor = r.Valor,
                    TipoDeAccion = r.TipoDeAccion,
                    FechaDeRegistro = r.FechaDeRegistro,
                    FechaDeModificacion = r.FechaDeModificacion,
                    IdTipoEntidad = r.IdTipoEntidad,
                    Estado = r.Estado
                }).ToListAsync();
        }
    }
}
