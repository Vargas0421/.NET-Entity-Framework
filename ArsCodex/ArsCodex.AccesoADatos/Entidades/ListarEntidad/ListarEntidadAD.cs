using ArsCodex.Abstracciones.AccesoADatos.Entidad.ListarEntidad;
using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Entidades.ListarEntidad
{
    public class ListarEntidadAD : IListarEntidadAD
    {
        private Contexto _contexto;
        public ListarEntidadAD()
        {
            _contexto = new Contexto();
        }
        public List<EntidadDto> Listar()
        {
            List<EntidadDto> laListaDeEntidad = (from Entidad in _contexto.Entidad
                                                 join TipoDeEntidades in _contexto.TipoDeEntidades on Entidad.idTipoEntidad equals TipoDeEntidades.idTipoEntidad
                                                 where Entidad.idEntidad == TipoDeEntidades.idTipoEntidad
                                                 select new EntidadDto
                                             {
                                                 idEntidad = Entidad.idEntidad,
                                                 codigoEntidad = Entidad.codigoEntidad,
                                                 nombreEntidad = Entidad.nombreEntidad,
                                                 telefonoEntidad = Entidad.telefonoEntidad,
                                                 correoElectronico = Entidad.correoElectronico,
                                                 direccion = Entidad.direccion,
                                                 fechaDeRegistro = Entidad.fechaDeRegistro,
                                                 fechaDeModificacion = Entidad.fechaDeModificacion,
                                                 estado = Entidad.estado,

                                                 idTipoEntidad = TipoDeEntidades.idTipoEntidad,
                                                 NombreTipoEntidad = TipoDeEntidades.nombreTipoEntidad,
                                                 }).ToList();
            return laListaDeEntidad;
        }
    }
}
