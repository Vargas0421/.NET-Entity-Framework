using ArsCodex.Abstracciones.AccesoADatos.Bitacora.ListarBitacora;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Bitacora.ListarBitacora
{
    public class ListarBitacoraAD : IListarBitacoraAD
    {
        private Contexto _contexto;
        public ListarBitacoraAD()
        {
            _contexto = new Contexto();
        }
        public List<BitacoraDto> Listar()
        {
            List<BitacoraAD> BitacorasAD = _contexto.Bitacoras.ToList();

            List<BitacoraDto> LaListaDeBitacoras = (from Bitacora in BitacorasAD
                                                                 select new BitacoraDto
                                                                 {
                                                                     IdEvento = Bitacora.idEvento,
                                                                        TablaDeEvento = Bitacora.tablaDeEvento,
                                                                        TipoDeEvento = Bitacora.tipoDeEvento,
                                                                        FechaDeEvento = Bitacora.fechaDeEvento,
                                                                        DescripcionDeEvento = Bitacora.descripcionDeEvento,
                                                                        StackTrace = Bitacora.stackTrace,
                                                                        DatosAnteriores = Bitacora.datosAnteriores,
                                                                        DatosPosteriores = Bitacora.datosPosteriores
                                                                 }).ToList();
            return LaListaDeBitacoras;
        }
    }
}
