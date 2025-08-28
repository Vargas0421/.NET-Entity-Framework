using ArsCodex.Abstracciones.AccesoADatos.Entidad.ObtenerEntidadPorId;
using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Entidades.ObtenerEntidadPorId
{
    public class ObtenerEntidadPorIdAD : IObtenerEntidadPorIdAD
    {
        private Contexto _contexto;

        public ObtenerEntidadPorIdAD()
        {
            _contexto = new Contexto();
        }
        public EntidadDto Obtener(int id)
        {
            //List<EntidadAD> EntidadADs = _contexto.Entidad.ToList();
            EntidadDto laListaDeEntidads = (from Entidad in _contexto.Entidad
                                            where Entidad.idEntidad == id
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
                                                idTipoEntidad = Entidad.idTipoEntidad,
                                                estado = Entidad.estado,
                                            })
                                            .FirstOrDefault();
            return laListaDeEntidads;
        }
    }
}
