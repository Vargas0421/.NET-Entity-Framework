using ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.EditarEntidad;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.ListarEntidad;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.RegistrarEntidad;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.ListarTipoDeEntidades;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Entidades.ObtenerEntidadPorId;
using ArsCodex.AccesoADatos.Modelos;
using ArsCodex.AccesoADatos.TipoDeEntidades.ObtenerTipoDeEntidades;
using ArsCodex.LogicaDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.LogicaDeNegocios.Entidad.EditarEntidad;
using ArsCodex.LogicaDeNegocios.Entidad.ListarEntidad;
using ArsCodex.LogicaDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.LogicaDeNegocios.Entidad.RegistrarEntidad;
using ArsCodex.LogicaDeNegocios.TipoDeEntidades.ListarTipoDeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArsCodex.UI.Controllers
{
    public class EntidadController : Controller
    {
        private readonly IListarEntidadLN _listarEntidad;
        private readonly IRegistrarEntidadLN _registrarEntidad;
        private readonly IListarTipoDeEntidadesLN _listarTipoDeEntidades;
        private readonly IObtenerEntidadPorIdLN _obtenerEntidadPorId;
        private readonly IEditarEntidadLN _editarEntidad;
        private readonly IAgregarBitacoraLN _agregarBitacoraLN;
        public EntidadController()
        {
            _listarEntidad = new ListarEntidadLN();
            _registrarEntidad = new RegistrarEntidadLN();
            _listarTipoDeEntidades = new ListarTipoDeEntidadesLN();
            _obtenerEntidadPorId = new ObtenerEntidadPorIdLN();
            _editarEntidad = new EditarEntidadLN();
            _agregarBitacoraLN = new AgregarBitacoraLN();
        }
        [Authorize(Roles = "Administrador")]
        // GET: Entidad
        public ActionResult listarEntidad()
        {
            List<EntidadDto> laListaDeEntidad = _listarEntidad.Listar();
            return View(laListaDeEntidad);
        }

        // GET: Entidad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entidad/Create
        public ActionResult RegistrarEntidad()
        {

            EntidadDto nuevaEntidad = new EntidadDto
            {
                fechaDeRegistro = DateTime.Now
            };


            List<TipoDeEntidadesDto> tiposDeEntidad = _listarTipoDeEntidades.Listar();

            ViewBag.ListaTiposDeEntidad = new SelectList(
                tiposDeEntidad,
                "IdTipoEntidad",
                "NombreTipoEntidad"
            );
            
            return View(nuevaEntidad);
        }

        // POST: Entidad/Create
        [HttpPost]
        public ActionResult RegistrarEntidad(EntidadDto laEntidad)
        {
            try
            {
                // TODO: Add insert logic here
                _registrarEntidad.Registrar(laEntidad);
                _agregarBitacoraLN.Ejecutar(
                    tabla: "Entidad",
                    tipoEvento: "Registrar",
                    datosAnteriores: laEntidad
                );
                return RedirectToAction("listarEntidad");
            }
            catch (Exception ex)
            {
                _agregarBitacoraLN.Ejecutar(
                tabla: "Entidad",
                tipoEvento: "Error",
                ex: ex
                );
                return View();
            }
        }

        // GET: Entidad/Edit/5
        public ActionResult EditarEntidad(int id)
        {
            EntidadDto laEntidad = _obtenerEntidadPorId.Obtener(id);
            laEntidad.fechaDeModificacion = DateTime.Now;
            return View(laEntidad);
        }

        // POST: Entidad/Edit/5
        [HttpPost]
        public ActionResult EditarEntidad(int id, EntidadDto laEntidad)
        {
            try
            {
                // TODO: Add update logic here
                var entidadAntes = new ObtenerEntidadPorIdAD().Obtener(laEntidad.idEntidad);

                laEntidad.fechaDeModificacion = DateTime.Now;
                _editarEntidad.Editar(laEntidad);
                _agregarBitacoraLN.Ejecutar(
                    tabla: "TipoEntidad",
                    tipoEvento: "Editar",
                    datosAnteriores: entidadAntes,
                    datosPosteriores: laEntidad
                );
                return RedirectToAction("listarEntidad");
            }
            catch (Exception ex)
            {
                _agregarBitacoraLN.Ejecutar(
                    tabla: "Entidad",
                    tipoEvento: "Error",
                    ex: ex
                );
                return View();
            }
        }

        // GET: Entidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entidad/Delete/5
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
