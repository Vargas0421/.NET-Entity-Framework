using ArsCodex.Abstracciones.AccesoADatos.Contadores.ListarContadores;
using ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.ListarContadores;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Contadores.ListarContadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Contadores.ListarContadores
{
    public class ListarContadoresLN : IListarContadoresLN
    {
        private readonly IListarContadoresAD _listarContadoresAD;

        public ListarContadoresLN()
        {
            _listarContadoresAD = new ListarContadoresAD();
        }

        public List<ContadoresDto> ListarContadores()
        {
            List<ContadoresDto> listaDeContadores = _listarContadoresAD.ListarContadores();
            return listaDeContadores;
        }

    }
}
