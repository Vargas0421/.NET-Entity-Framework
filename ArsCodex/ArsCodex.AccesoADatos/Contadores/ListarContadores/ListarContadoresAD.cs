using ArsCodex.Abstracciones.AccesoADatos.Contadores.ListarContadores;
using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Contadores.ListarContadores
{
    public class ListarContadoresAD : IListarContadoresAD
    {
        private Contexto _contexto;

        public ListarContadoresAD()
        { 
            _contexto = new Contexto();
        }

        public List<ContadoresDto> ListarContadores()
        {
            List<ContadoresDto> listaDeContadores = (from contador in _contexto.Contadores
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


                                                     }).ToList();
            return listaDeContadores;
        }
    }
}
