using ArsCodex.Abstracciones.AccesoADatos.Entidad.RegistrarEntidad;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Entidades.RegistrarEntidad
{
    public class RegistrarEntidadAD : IRegistrarEntidadAD
    {
        private Contexto _contexto;

        public RegistrarEntidadAD()
        {
            _contexto = new Contexto();
        }
        public async Task<int> Registrar(EntidadDto elEntidadParaGuardar)
        {
            EntidadAD elEntidadAGuardar = ConvertirObjeto(elEntidadParaGuardar);
            _contexto.Entidad.Add(elEntidadAGuardar);
            int cantidadDeDatosAlmacenados = await _contexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
        private EntidadAD ConvertirObjeto(EntidadDto elEntidadParaGuardar)
        {
            return new EntidadAD
            {
                idTipoEntidad = elEntidadParaGuardar.idTipoEntidad,
                codigoEntidad = elEntidadParaGuardar.codigoEntidad,
                nombreEntidad = elEntidadParaGuardar.nombreEntidad,
                telefonoEntidad = elEntidadParaGuardar.telefonoEntidad,
                correoElectronico = elEntidadParaGuardar.correoElectronico,
                direccion = elEntidadParaGuardar.direccion,
                fechaDeRegistro = DateTime.Now,
                fechaDeModificacion = DateTime.Now,
                estado = true
            };

        }
    }
}
