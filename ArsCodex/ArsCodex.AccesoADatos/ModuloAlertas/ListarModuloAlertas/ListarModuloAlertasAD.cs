using ArsCodex.Abstracciones.AccesoADatos.ModuloAlertas.ListarModuloAlertas;
using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.ModuloAlertas.ListarModuloAlertas
{ 
    public class ListarModuloAlertasAD : IListarModuloAlertasAD
    {
        private Contexto _contexto;

        public ListarModuloAlertasAD()
        {
            _contexto = new Contexto();
        }
        public List<ModuloAlertasDto> ListarAlertas()
        {
            List<ModuloAlertasDto> listaDeAlertas = (from alerta in _contexto.ModuloAlertas
                                                     join ent in _contexto.Entidad
                                                       on alerta.IdEntidad equals ent.idEntidad
                                                     join cont in _contexto.Contadores
                                                       on alerta.IdContador equals cont.IdContador
                                                     select new ModuloAlertasDto
                                                     {
                                                         IdAlerta = alerta.IdAlerta,
                                                         IdEntidad = alerta.IdEntidad,
                                                         NombreDeLaEntidad = ent.nombreEntidad,
                                                         IdContador = alerta.IdContador,
                                                         NombreDelContador = cont.NombreContador,
                                                         Periodo = alerta.Periodo,
                                                         CantidadDeReglasIncumplidas = alerta.CantidadDeReglasIncumplidas,
                                                         IdReservaLiquidez = alerta.IdReservaLiquidez,
                                                         FechaDeRegistro = alerta.FechaDeRegistro,
                                                         FechaDeModificacion = alerta.FechaDeModificacion,
                                                         Estado = alerta.Estado
                                                     }).ToList();
            return listaDeAlertas;
        }
    }
}
