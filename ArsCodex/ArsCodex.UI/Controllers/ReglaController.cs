using ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.EditarRegla;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.ListarRegla;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.ObtenerReglaPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.Regla.RegistrarRegla;
using ArsCodex.Abstracciones.LogicasDeNegocios.TipoDeEntidades.ObtenerTipoDeEntidadesPorId;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using ArsCodex.AccesoADatos.Regla.ObtenerReglaPorId;
using ArsCodex.AccesoADatos.TipoDeEntidades.ObtenerTipoDeEntidades;
using ArsCodex.LogicaDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.LogicaDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.LogicaDeNegocios.Regla.ActivarInactivarRegla;
using ArsCodex.LogicaDeNegocios.Regla.EditarRegla;
using ArsCodex.LogicaDeNegocios.Regla.ListarRegla;
using ArsCodex.LogicaDeNegocios.Regla.ObtenerReglaPorId;
using ArsCodex.LogicaDeNegocios.Regla.RegistrarRegla;
using ArsCodex.LogicaDeNegocios.TipoDeEntidades.ObtenerTipoDeEntidadesPorId;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArsCodex.UI.Controllers
{
    public class ReglaController : Controller
    {
        private readonly IListarReglaLN _listarReglaLN;
        private readonly IObtenerReglaPorIdLN _obtenerReglaPorIdLN;
        private readonly IRegistrarReglaLN _registrarReglaLN;
        private readonly IEditarReglaLN _editarReglaLN;
        private readonly IAgregarBitacoraLN _agregarBitacoraLN;
        private readonly IObtenerTipoDeEntidadesPorIdLN _obtenerTipoDeEntidadesPorIdLN;


        public ReglaController()
        {
            _listarReglaLN = new ListarReglaLN();
            _obtenerReglaPorIdLN = new ObtenerReglaPorIdLN();
            _registrarReglaLN = new RegistrarReglaLN();
            _editarReglaLN = new EditarReglaLN();
            _agregarBitacoraLN = new AgregarBitacoraLN();
            _obtenerTipoDeEntidadesPorIdLN = new ObtenerTipoDeEntidadesPorIdLN();
        }

        [Authorize(Roles = "Administrador")]

        // GET: Regla
        public ActionResult ListarRegla(int idTipoEntidad)
        {
            var reglas = _listarReglaLN.Listar(idTipoEntidad);

            ViewBag.IdTipoEntidad = idTipoEntidad; // Necesario para que el ActionLink funcione
            
            return View(reglas);
        }

        // GET: Regla/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Regla/Create
        public ActionResult RegistrarRegla(int idTipoEntidad)
        {
            var tipoEntidad = _obtenerTipoDeEntidadesPorIdLN.Obtener(idTipoEntidad);
            if (tipoEntidad == null)
            {
                TempData["Error"] = "El tipo de entidad especificado no existe.";
                return RedirectToAction("ListarRegla", new { idTipoEntidad = 0 }); 
            }

            /*var opciones = new[]
            {
                new { Value = "MontoDeReserva",         Text = "Monto De Reserva" },
                new { Value = "MontoDeSeguroBancario",  Text = "Monto De Seguro Bancario" },
                new { Value = "CantidadDeBeneficiarios",Text = "Cantidad De Beneficiarios" }
            };
            ViewBag.Opciones = new SelectList(opciones, "Value", "Text");
            */
            ViewBag.NombreTipoEntidad = tipoEntidad.NombreTipoEntidad;

            var modelo = new ReglaDto
            {
                IdTipoEntidad = idTipoEntidad,
                FechaDeRegistro = DateTime.Now
            };

            return View(modelo);
        }

        // POST: Regla/RegistrarRegla
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarRegla(ReglaDto LaReglaParaGuardar)
        {
            var tipoEntidad = _obtenerTipoDeEntidadesPorIdLN.Obtener(LaReglaParaGuardar.IdTipoEntidad);
            if (tipoEntidad == null)
            {
                ModelState.AddModelError("", "Tipo de entidad inválido.");
                return View(LaReglaParaGuardar);
            }

            ViewBag.NombreTipoEntidad = tipoEntidad.NombreTipoEntidad;

            if (!ModelState.IsValid)
            {
                return View(LaReglaParaGuardar);
            }

            try
            {
                LaReglaParaGuardar.FechaDeRegistro = DateTime.Now;
                

                int resultado = await _registrarReglaLN.Registrar(LaReglaParaGuardar);

                _agregarBitacoraLN.Ejecutar(
                    tabla: "Regla",
                    tipoEvento: "Registrar",
                    datosAnteriores: LaReglaParaGuardar
                );

                return RedirectToAction("ListarRegla", new { idTipoEntidad = LaReglaParaGuardar.IdTipoEntidad });
            }
            catch (Exception ex)
            {
                _agregarBitacoraLN.Ejecutar(
                    tabla: "Regla",
                    tipoEvento: "Error",
                    ex: ex
                );


                ModelState.AddModelError("", "Error al registrar la regla: " + ex.Message);
                return View(LaReglaParaGuardar);
            }
        }


        // GET: Regla/Edit/5
        public ActionResult EditarRegla(int id)
        {
            var regla = new ObtenerReglaPorIdAD().Obtener(id);
            /*var opciones = new[]
{
                    new { Value = "MontoDeReserva",         Text = "Monto De Reserva" },
                    new { Value = "MontoDeSeguroBancario",  Text = "Monto De Seguro Bancario" },
                    new { Value = "CantidadDeBeneficiarios",Text = "Cantidad De Beneficiarios" }
                };
            ViewBag.Opciones = new SelectList(opciones, "Value", "Text", regla.Nombre);
            */

            return View(regla);
        }

        // POST: Regla/Edit/5
        [HttpPost]
        public ActionResult EditarRegla(ReglaDto Regla)
        {
            try
            {
                var entidadAntes = new ObtenerReglaPorIdAD().Obtener(Regla.IdRegla);

                Regla.FechaDeModificacion = DateTime.Now;
                _editarReglaLN.Editar(Regla);



                _agregarBitacoraLN.Ejecutar(
                    tabla: "Regla",
                    tipoEvento: "Editar",
                    datosAnteriores: entidadAntes,
                    datosPosteriores: Regla
                );

                return RedirectToAction("ListarRegla", new { idTipoEntidad = Regla.IdTipoEntidad });
            }
            catch (Exception ex)
            {
                _agregarBitacoraLN.Ejecutar(
                    tabla: "Regla",
                    tipoEvento: "Error",
                    ex: ex
                );
                
                return View(Regla);
            }
        }

        // GET: Regla/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Regla/ToggleEstado/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ToggleEstado(int id)
        {
            try
            {
                var nuevoEstado = await new ActivarInactivarReglaLN().Ejecutar(id);

                _agregarBitacoraLN.Ejecutar(
                    tabla: "Regla",
                    tipoEvento: "Editar Estado",
                    datosAnteriores: new { IdRegla = id, Estado = !nuevoEstado },
                    datosPosteriores: new { IdRegla = id, Estado = nuevoEstado }
                );

                return Json(new { ok = true, estado = nuevoEstado ? "Activo" : "Inactivo" });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, error = ex.Message });
            }
        }
    }
}
