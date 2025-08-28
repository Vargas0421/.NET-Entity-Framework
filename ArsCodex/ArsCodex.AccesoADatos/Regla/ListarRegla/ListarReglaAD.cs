using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.Regla.ListarRegla;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;

namespace ArsCodex.AccesoADatos.Regla.ListarRegla
{
    public class ListarReglaAD : IListarReglaAD
    {
        private Contexto _contexto;

        public ListarReglaAD()
        {
            _contexto = new Contexto();
        }

        public List<ReglaDto> Listar(int idTipoEntidad)
        {
            List<ReglaAD> reglasAD = _contexto.Reglas.ToList();
            List<ReglaDto> listaDeReglas = (from regla in reglasAD
                                            where regla.IdTipoEntidad == idTipoEntidad 
                                            select new ReglaDto
                                            {
                                                IdRegla = regla.IdRegla,
                                                Nombre = regla.Nombre,
                                                Descripcion = regla.Descripcion,
                                                Valor = regla.Valor,
                                                TipoDeAccion = regla.TipoDeAccion,
                                                FechaDeRegistro = regla.FechaDeRegistro,
                                                Estado = regla.Estado
                                            }).ToList();
            return listaDeReglas;
        }
    }
}
