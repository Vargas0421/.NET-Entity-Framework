using ArsCodex.Abstracciones.AccesoADatos.Contadores.AgregarContadores;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace ArsCodex.AccesoADatos.Contadores.AgregarContadores
{
    public class AgregarContadoresAD : IAgregarContadoresAD
    { 
        private Contexto _contexto;

        public AgregarContadoresAD()
        {
            _contexto = new Contexto();
        }

        public async Task<int> AgregarContadores(ContadoresDto elContadorAAgregarDto)
        {
            ContadoresAD elContadorAAgregarAD = ConvertirObjeto(elContadorAAgregarDto);
            _contexto.Contadores.Add(elContadorAAgregarAD);
            int cantidadDeFilasAfectadas = await _contexto.SaveChangesAsync();
            return cantidadDeFilasAfectadas;

        }

        private ContadoresAD ConvertirObjeto(ContadoresDto elContadorAAgregarDto)
        {
            return new ContadoresAD
            {
                IdContador = elContadorAAgregarDto.IdContador,
                IdContadorIdentity = elContadorAAgregarDto.IdContadorIdentity,
                IdentificacionContador = elContadorAAgregarDto.IdentificacionContador,
                NombreContador = elContadorAAgregarDto.NombreContador,
                PrimerApellidoContador = elContadorAAgregarDto.PrimerApellidoContador,
                SegundoApellidoContador = elContadorAAgregarDto.SegundoApellidoContador,
                NumeroDeColegio = elContadorAAgregarDto.NumeroDeColegio,
                CorreoElectronico = elContadorAAgregarDto.CorreoElectronico,
                TelefonoCelular = elContadorAAgregarDto.TelefonoCelular,
                TelefonoSecundario = elContadorAAgregarDto.TelefonoSecundario,
                MetodoDeContacto = elContadorAAgregarDto.MetodoDeContacto,
                FechaDeRegistro = elContadorAAgregarDto.FechaDeRegistro,
                FechaDeModificacion = elContadorAAgregarDto.FechaDeModificacion,
                Estado = elContadorAAgregarDto.Estado

            };
        }
    }
}
