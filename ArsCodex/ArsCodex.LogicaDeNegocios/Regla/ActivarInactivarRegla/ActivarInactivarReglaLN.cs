using ArsCodex.Abstracciones.AccesoADatos.Regla.ActivarInactivarRegla;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.ActivarInactivarRegla;
using ArsCodex.AccesoADatos.Regla.ActivarInactivarRegla;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Regla.ActivarInactivarRegla
{
    public class ActivarInactivarReglaLN : IActivarInactivarReglaLN
    {
        private readonly ActivarInactivarReglaAD _activarInactivarRegla;

        public ActivarInactivarReglaLN()
        {
            _activarInactivarRegla = new ActivarInactivarReglaAD();
        }

        public async Task<bool> Ejecutar(int idRegla)
        {
            return await _activarInactivarRegla.ToggleAsync(idRegla);
        }
    }
}
