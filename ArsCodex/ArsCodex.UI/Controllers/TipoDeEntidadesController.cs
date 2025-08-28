using ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.EditarTiposDeEntidades;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.ListarTipoDeEntidades;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.ObtenerTipoDeEntidadesPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.RegistrarTipoDeEntidades;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using ArsCodex.AccesoADatos.TipoDeEntidades.ObtenerTipoDeEntidades;
using ArsCodex.LogicaDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.LogicaDeNegocios.TipoDeEntidades.EditarTipoDeEntidades;
using ArsCodex.LogicaDeNegocios.TipoDeEntidades.ListarTipoDeEntidades;
using ArsCodex.LogicaDeNegocios.TipoDeEntidades.ObtenerTipoDeEntidadesPorId;
using ArsCodex.LogicaDeNegocios.TipoDeEntidades.RegistrarTipoDeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArsCodex.UI.Controllers
{
    public class TipoDeEntidadesController : Controller
    {
        private readonly IListarTipoDeEntidadesLN _listarTipoDeEntidadesLN;
        private readonly IObtenerTipoDeEntidadesPorIdLN _obtenerTipoDeEntidadesPorIdLN;
        private readonly IRegistrarTipoDeEntidadesLN _registrarTipoDeEntidadesLN;
        private readonly IEditarTipoDeEntidadesLN _editarTipoDeEntidadesLN;
        private readonly IAgregarBitacoraLN _agregarBitacoraLN;
        public TipoDeEntidadesController()
        {
            _listarTipoDeEntidadesLN = new ListarTipoDeEntidadesLN();
            _obtenerTipoDeEntidadesPorIdLN = new ObtenerTipoDeEntidadesPorIdLN();
            _registrarTipoDeEntidadesLN = new RegistrarTipoDeEntidadesLN();
            _editarTipoDeEntidadesLN = new EditarTipoDeEntidadesLN();
            _agregarBitacoraLN = new AgregarBitacoraLN();
        }

        [Authorize(Roles = "Administrador")]

        // GET: TipoDeEntidades
        public ActionResult ListarTipoDeEntidades()
        {
            List<TipoDeEntidadesDto> laListaDeTipoDeEntidades = _listarTipoDeEntidadesLN.Listar();
            return View(laListaDeTipoDeEntidades);
        }

        // GET: TipoDeEntidades/Details/5
        public ActionResult Detalles(int id)
        {
            TipoDeEntidadesDto ElTipoDeEntidad = _obtenerTipoDeEntidadesPorIdLN.Obtener(id);
            return View(ElTipoDeEntidad);
        }

        // GET: TipoDeEntidades/Create
        public ActionResult RegistrarTipoDeEntidades()
        {
            return View();
        }

        // POST: TipoDeEntidades/Create
        [HttpPost]
        public async Task<ActionResult> RegistrarTipoDeEntidades(TipoDeEntidadesDto ElTipoDeEntidadParaGuardar )
        {
            try
            {

                // TODO: Add insert logic here
                ElTipoDeEntidadParaGuardar.FechaDeRegistro = DateTime.Now;
                int cantidadDeDatosAlmacencados = await _registrarTipoDeEntidadesLN.Registrar(ElTipoDeEntidadParaGuardar);
                _agregarBitacoraLN.Ejecutar(
                    tabla: "TipoEntidad",
                    tipoEvento: "Registrar",
                    datosAnteriores: ElTipoDeEntidadParaGuardar
                );
                return RedirectToAction("ListarTipoDeEntidades");

            }
            catch (Exception ex)
            {
                _agregarBitacoraLN.Ejecutar(
                tabla: "TipoEntidad",
                tipoEvento: "Error",
                ex: ex
                );
                return View();
            }
        }

        // GET: TipoDeEntidades/Edit/5
        public ActionResult EditarTipoDeEntidades(int id)
        {
            {
               var TipoDeEntidad = new ObtenerTipoDeEntidadesPorIdAD().Obtener(id);
                return View(TipoDeEntidad);
            }
        }

        // POST: TipoDeEntidades/Edit/5
        [HttpPost]
        public ActionResult EditarTipoDeEntidades(TipoDeEntidadesDto TipoDeEntidades)
        {
            try
            {
                // Obtener estado anterior para la bitácora
                var entidadAntes = new ObtenerTipoDeEntidadesPorIdAD().Obtener(TipoDeEntidades.IdTipoEntidad);

                TipoDeEntidades.FechaDeModificacion = DateTime.Now;
                _editarTipoDeEntidadesLN.Editar(TipoDeEntidades);

                _agregarBitacoraLN.Ejecutar(
                    tabla: "TipoEntidad",
                    tipoEvento: "Editar",
                    datosAnteriores: entidadAntes,
                    datosPosteriores: TipoDeEntidades
                );
                return RedirectToAction("ListarTipoDeEntidades");
            }
            catch (Exception ex)
            {
                _agregarBitacoraLN.Ejecutar(
                    tabla: "TipoEntidad",
                    tipoEvento: "Error",
                    ex: ex
                );

                return View(TipoDeEntidades);
            }
        }

        // GET: TipoDeEntidades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoDeEntidades/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
