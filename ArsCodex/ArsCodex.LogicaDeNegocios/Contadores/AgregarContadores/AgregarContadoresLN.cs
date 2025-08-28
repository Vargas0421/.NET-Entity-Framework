using ArsCodex.Abstracciones.AccesoADatos.Contadores.AgregarContadores;
using ArsCodex.Abstracciones.Comunes.Fecha;
using ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.AgregarContadores;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Contadores.AgregarContadores;
using ArsCodex.LogicaDeNegocios.Comunes.Fecha;
using System;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Contadores.AgregarContadores
{
    public class AgregarContadoresLN : IAgregarContadoresLN
    {
        private IAgregarContadoresAD _agregarContadoresAD;
        private readonly IFechaLN _fecha;
        int zonaHoraria = 0; 

        public AgregarContadoresLN( )
        {
            _agregarContadoresAD = new AgregarContadoresAD();
            _fecha = new FechaLN();
            zonaHoraria = -6;
        }
        public async Task<int> AgregarContadores(ContadoresDto elContadorAAgregarDto)
        {
            elContadorAAgregarDto.FechaDeRegistro = _fecha.ObtenerFechaPorZonaHoraria(zonaHoraria);
            elContadorAAgregarDto.IdContadorIdentity = Guid.NewGuid(); // Generar un nuevo GUID para el contador
            elContadorAAgregarDto.Estado = true; // Por defecto, el contador estará activo al momento de ser agregado.
            int cantidadDeFilasAfectadas = await _agregarContadoresAD.AgregarContadores(elContadorAAgregarDto);
            return cantidadDeFilasAfectadas;
        }
    }
}
