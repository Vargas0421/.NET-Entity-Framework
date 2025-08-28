using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArsCodex.Abstracciones.AccesoADatos.Regla.EditarRegla;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;

namespace ArsCodex.AccesoADatos.Regla.EditarRegla
{
    public class EditarReglaAD : IEditarReglaAD
    {
        private Contexto _contexto;

        public EditarReglaAD()
        {
            _contexto = new Contexto();
        }

        public int Editar(ReglaDto LaReglaParaGuardar)
        {
            int cantidadDeDatosAlmacenados = 0;
            ReglaAD ReglaEnLaBd = _contexto.Reglas.Where(regla => regla.IdRegla == LaReglaParaGuardar.IdRegla).FirstOrDefault();
            if (ReglaEnLaBd != null)
            {
                ReglaEnLaBd.Nombre = LaReglaParaGuardar.Nombre;
                ReglaEnLaBd.Descripcion = LaReglaParaGuardar.Descripcion;
                ReglaEnLaBd.Valor = LaReglaParaGuardar.Valor;
                ReglaEnLaBd.TipoDeAccion = LaReglaParaGuardar.TipoDeAccion;
                ReglaEnLaBd.FechaDeModificacion = ReglaEnLaBd.FechaDeModificacion ?? DateTime.Now;
                ReglaEnLaBd.Estado = LaReglaParaGuardar.Estado;
                cantidadDeDatosAlmacenados = _contexto.SaveChanges();
            }
            return cantidadDeDatosAlmacenados;
        }
    }
}
