using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.Regla.ObtenerReglaPorId;
using ArsCodex.Abstracciones.ModelosParaUI;

namespace ArsCodex.AccesoADatos.Regla.ObtenerReglaPorId
{
    public class ObtenerReglaPorIdAD : IObtenerReglaPorIdAD
    {
        private readonly Contexto _contexto;

        public ObtenerReglaPorIdAD()
        {
            _contexto = new Contexto();
        }

        public ReglaDto Obtener(int id)
        {
            ReglaDto laRegla = (from regla in _contexto.Reglas
                                where regla.IdRegla == id
                                select new ReglaDto
                                {
                                    IdRegla = regla.IdRegla,
                                    Nombre = regla.Nombre,
                                    Descripcion = regla.Descripcion,
                                    Valor = regla.Valor,
                                    TipoDeAccion = regla.TipoDeAccion,
                                    FechaDeRegistro = regla.FechaDeRegistro,
                                    FechaDeModificacion = regla.FechaDeModificacion,
                                    IdTipoEntidad = regla.IdTipoEntidad,
                                    Estado = regla.Estado
                                }).FirstOrDefault();
            return (laRegla);
        }
    }
}
