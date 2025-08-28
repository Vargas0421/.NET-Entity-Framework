using ArsCodex.Abstracciones.AccesoADatos.Contadores.EditarContadores;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Contadores.EditarContadores
{
    public class EditarContadoresAD : IEditarContadoresAD
    {
        private Contexto _contexto;

        public EditarContadoresAD()
        {
            _contexto = new Contexto();
        }
        public int EditarContadores(ContadoresDto elContadorParaEditar)
        {
            int cantidadDeFilasAfectadas = 0;
            ContadoresAD elContadorEnBaseDeDAtos = _contexto.Contadores.Where(contadores => contadores.IdContador == elContadorParaEditar.IdContador).FirstOrDefault();
            if(elContadorEnBaseDeDAtos != null)
            {
                
                elContadorEnBaseDeDAtos.NombreContador = elContadorParaEditar.NombreContador;
                elContadorEnBaseDeDAtos.PrimerApellidoContador = elContadorParaEditar.PrimerApellidoContador;
                elContadorEnBaseDeDAtos.SegundoApellidoContador = elContadorParaEditar.SegundoApellidoContador;
                elContadorEnBaseDeDAtos.NumeroDeColegio = elContadorParaEditar.NumeroDeColegio;
                elContadorEnBaseDeDAtos.CorreoElectronico = elContadorParaEditar.CorreoElectronico;
                elContadorEnBaseDeDAtos.TelefonoCelular = elContadorParaEditar.TelefonoCelular;
                elContadorEnBaseDeDAtos.TelefonoSecundario = elContadorParaEditar.TelefonoSecundario;
                elContadorEnBaseDeDAtos.MetodoDeContacto = elContadorParaEditar.MetodoDeContacto;
                elContadorEnBaseDeDAtos.FechaDeModificacion = elContadorParaEditar.FechaDeModificacion;
                elContadorEnBaseDeDAtos.Estado = elContadorParaEditar.Estado;
                cantidadDeFilasAfectadas = _contexto.SaveChanges();
            }
            return cantidadDeFilasAfectadas;
        }

}
}

