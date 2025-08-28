using ArsCodex.Abstracciones.AccesoADatos.ModuloAlertas.RegistrarModuloAlertas;
using ArsCodex.Abstracciones.LogicasDeNegocios.ModuloAlertas.RegistrarModuloAlertas;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.ModuloAlertas.RegistrarModuloAlertas;
using System;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.ModuloAlertas.RegistrarModuloAlertas
{
    public class RegistrarModuloAlertasLN : IRegistrarModuloAlertasLN
    {
        private readonly IRegistrarModuloAlertasAD _registrarAD;

        public RegistrarModuloAlertasLN()
        {
            _registrarAD = new RegistrarModuloAlertasAD();
        }

        public async Task<int> RegistrarAlerta(ModuloAlertasDto alertaAGuardar)
        {
            
            alertaAGuardar.FechaDeRegistro = DateTime.Now;
            alertaAGuardar.FechaDeModificacion = DateTime.Now;
            alertaAGuardar.Estado = true;
            alertaAGuardar.IdContador = 1; // Aquí se pone el ID del contador actual, cuando este el login implementado
            int cantidadDeDatosAlmacenados = await _registrarAD.RegistrarAlerta(alertaAGuardar);
            
            return cantidadDeDatosAlmacenados;
        }
    }
}       