using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Contadores.ObtenerContadoresPorId
{
    public class ObtenerContadoresPorIdAD
    {
        private Contexto _contexto;

        public ObtenerContadoresPorIdAD()
        {
            _contexto = new Contexto();
        }
        public ContadoresDto ObtenerContadorPorId(int id)
        {
            ContadoresDto contadorDelId = (from contador in _contexto.Contadores
                                            where contador.IdContador    == id
                                            select new ContadoresDto
                                            {
                                                IdContador = contador.IdContador,
                                                IdContadorIdentity = contador.IdContadorIdentity,
                                                IdentificacionContador = contador.IdentificacionContador,
                                                NombreContador = contador.NombreContador,
                                                PrimerApellidoContador = contador.PrimerApellidoContador,
                                                SegundoApellidoContador = contador.SegundoApellidoContador,
                                                NumeroDeColegio = contador.NumeroDeColegio,
                                                CorreoElectronico = contador.CorreoElectronico,
                                                TelefonoCelular = contador.TelefonoCelular,
                                                TelefonoSecundario = contador.TelefonoSecundario,
                                                MetodoDeContacto = contador.MetodoDeContacto,
                                                FechaDeRegistro = contador.FechaDeRegistro,
                                                FechaDeModificacion = contador.FechaDeModificacion,
                                                Estado = contador.Estado

                                            }).FirstOrDefault();
            return contadorDelId;
        }
    }
}
