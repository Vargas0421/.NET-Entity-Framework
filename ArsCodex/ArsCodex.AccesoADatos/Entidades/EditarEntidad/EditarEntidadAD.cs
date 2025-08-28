using ArsCodex.Abstracciones.AccesoADatos.Entidad.EditarEntidad;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Entidades.EditarEntidad
{
    public class EditarEntidadAD : IEditarEntidadAD
    {
        private Contexto _contexto;
        public EditarEntidadAD()
        {
            _contexto = new Contexto();
        }
        public int Editar(EntidadDto elEntidadParaGuardar)
        {
            int cantidadDeDatosAlmacenados = 0;
            EntidadAD laEntidadEnBaseDeDatos = _contexto.Entidad.Where(Entidad => Entidad.idEntidad == elEntidadParaGuardar.idEntidad).FirstOrDefault();
            if (laEntidadEnBaseDeDatos != null)
            {
                laEntidadEnBaseDeDatos.idEntidad = elEntidadParaGuardar.idEntidad;
                laEntidadEnBaseDeDatos.codigoEntidad = elEntidadParaGuardar.codigoEntidad;
                laEntidadEnBaseDeDatos.nombreEntidad = elEntidadParaGuardar.nombreEntidad;
                laEntidadEnBaseDeDatos.telefonoEntidad = elEntidadParaGuardar.telefonoEntidad;
                laEntidadEnBaseDeDatos.correoElectronico = elEntidadParaGuardar.correoElectronico;
                laEntidadEnBaseDeDatos.direccion = elEntidadParaGuardar.direccion;
                laEntidadEnBaseDeDatos.fechaDeRegistro = elEntidadParaGuardar.fechaDeRegistro ?? DateTime.Now;
                laEntidadEnBaseDeDatos.fechaDeModificacion = elEntidadParaGuardar.fechaDeModificacion ?? DateTime.Now;
                laEntidadEnBaseDeDatos.estado = elEntidadParaGuardar.estado;
                laEntidadEnBaseDeDatos.idTipoEntidad = elEntidadParaGuardar.idTipoEntidad;
                cantidadDeDatosAlmacenados = _contexto.SaveChanges();
            }
            return cantidadDeDatosAlmacenados;
        }
    }
}
