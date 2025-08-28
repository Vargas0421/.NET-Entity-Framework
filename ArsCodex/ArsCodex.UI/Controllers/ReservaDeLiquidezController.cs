using ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.ListarEntidad;
using ArsCodex.Abstracciones.LogicasDeNegocios.ModuloAlertas.EditarModuloAlertas;
using ArsCodex.Abstracciones.LogicasDeNegocios.ModuloAlertas.RegistrarModuloAlertas;
using ArsCodex.Abstracciones.LogicasDeNegocios.ReservaDeLiquidez.EditarReservaDeLiquidez;
using ArsCodex.Abstracciones.LogicasDeNegocios.ReservaDeLiquidez.ListarReservaDeLiquidez;
using ArsCodex.Abstracciones.LogicasDeNegocios.ReservaDeLiquidez.RegistrarReservaDeLiquidezLN;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.ReservaDeLiquidez.RegistrarReservaDeLiquidez;
using ArsCodex.LogicaDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.LogicaDeNegocios.Contadores.ListarContadores;
using ArsCodex.LogicaDeNegocios.Entidad.ListarEntidad;
using ArsCodex.LogicaDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.LogicaDeNegocios.ModuloAlertas.EditarModuloAlertas;
using ArsCodex.LogicaDeNegocios.ModuloAlertas.RegistrarModuloAlertas;
using ArsCodex.LogicaDeNegocios.Regla.ActivarInactivarRegla;
using ArsCodex.LogicaDeNegocios.Regla.QueryReglas;
using ArsCodex.LogicaDeNegocios.ReservaDeLiquidez.EditarReservaDeLiquidez;
using ArsCodex.LogicaDeNegocios.ReservaDeLiquidez.ListarReservaDeLiquidez;
using ArsCodex.LogicaDeNegocios.ReservaDeLiquidez.RegistrarReservaDeLiquidez;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArsCodex.UI.Controllers
{
    public class ReservaDeLiquidezController : Controller
    {
        private readonly IListarReservaDeLiquidezLN _listarReservaDeLiquidezLN;
        private readonly IRegistrarReservaDeLiquidezLN _registrarReservaDeLiquidezLN;
        private readonly IListarEntidadLN _listarEntidad;
        private readonly IEditarReservaDeLiquidezLN _editarReservaDeLiquidezLN;
        private readonly IAgregarBitacoraLN _agregarBitacoraLN;
        private readonly IRegistrarModuloAlertasLN _registrarAlertasLN;
        private readonly IEditarModuloAlertasLN _editarAlertasLN;

        public ReservaDeLiquidezController()
        {
            _listarReservaDeLiquidezLN = new ListarReservaDeLiquidezLN();
            _registrarReservaDeLiquidezLN = new RegistrarReservaDeLiquidezLN();
            _listarEntidad = new ListarEntidadLN();
            _editarReservaDeLiquidezLN = new EditarReservaDeLiquidezLN();
            _agregarBitacoraLN = new AgregarBitacoraLN();
            _registrarAlertasLN = new RegistrarModuloAlertasLN();
            _editarAlertasLN = new EditarModuloAlertasLN();

        }
        // GET: ReservaDeLiquidez
        public ActionResult ListarReservaDeLiquidez()
        {
            List<ReservaDeLiquidezDto> listaDeReservaDeLiquidez = _listarReservaDeLiquidezLN.ListarReservaDeLiquidez();

            // Catálogo de Entidades
            var entidades = _listarEntidad.Listar()
                .ToDictionary(e => e.idEntidad, e => e.nombreEntidad);

            // Catálogo de Contadores (ajusta al LN/AD que tengas)
            var contadores = new ListarContadoresLN().ListarContadores()
                .ToDictionary(c => c.IdContador, c => c.NombreContador);

            foreach (var r in listaDeReservaDeLiquidez)
            {
                if (entidades.TryGetValue(r.IdEntidad, out var nomEnt))
                    r.NombreEntidad = nomEnt;

                if (contadores.TryGetValue(r.IdContador, out var nomCont))
                    r.NombreContador = nomCont;
            }
            return View(listaDeReservaDeLiquidez);


        }

        // GET: ReservaDeLiquidez/Details/5
        public ActionResult DetalleReservaDeLiquidez(int id)
        {
            return View();
        }


        // GET: ReservaDeLiquidez/Create
        public ActionResult RegistrarReservaDeLiquidez()
        {
            
            var nuevaReserva = new ReservaDeLiquidezDto
            {
                FechaDeRegistro = DateTime.Now,
                IdContador = 1//ObtenerIdContadorActual()  // método que extrae tu userId del contexto
            };
            CargarListasEnViewBag();

            return View(nuevaReserva);
        }

        // POST: ReservaDeLiquidez/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarReservaDeLiquidez(ReservaDeLiquidezDto model,
        int PeriodoMes,
        int PeriodoAnio)
        {
            try
            {
                // Asignar el periodo
                model.Periodo = new DateTime(PeriodoAnio, PeriodoMes, 1);

                // Validaciones de modelo
                if (!ModelState.IsValid)
                {
                    CargarListasEnViewBag();
                    return View(model);
                }

                // Comprobar duplicado
                var ad = new RegistrarReservaDeLiquidezAD();
                bool existe = await ad.ExisteReservaParaPeriodo(model.IdEntidad, model.Periodo);
                if (existe)
                {
                    ModelState.AddModelError("",
                        "Ya existe una reserva de liquidez para la entidad y periodo seleccionados.");
                    CargarListasEnViewBag();
                    return View(model);
                }


                var reglas = await new QueryReglasLN()
                              .Evaluar(model,
                                       new ObtenerEntidadPorIdLN()
                                         .Obtener(model.IdEntidad)
                                         .idTipoEntidad);


                    // Insertar
                    model.IdReservaLiquidez = await _registrarReservaDeLiquidezLN.RegistrarReservaDeLiquidez(model);

                _agregarBitacoraLN.Ejecutar(
                    tabla: "ReservaDeLiquidez",
                    tipoEvento: "Registrar",
                    datosAnteriores: model
                );

                if (reglas.Any())
                {
                    var alerta = new ModuloAlertasDto
                    {
                        IdEntidad = model.IdEntidad,
                        IdContador = 1,//model.IdContador,
                        Periodo = model.Periodo.ToString("MMMM yyyy"),
                        CantidadDeReglasIncumplidas = reglas.Count,
                        IdReservaLiquidez = model.IdReservaLiquidez,
                        FechaDeRegistro = DateTime.Now,
                        FechaDeModificacion = DateTime.Now,
                        Estado = true
                    };
                    await _registrarAlertasLN.RegistrarAlerta(alerta);

                    // Bitácora: Agregar Alerta
                    _agregarBitacoraLN.Ejecutar(
                        tabla: "Alerta",
                        tipoEvento: "Registrar",
                        datosAnteriores: alerta
                    );
                }

                TempData["Success"] = "Reserva de liquidez registrada correctamente.";
                return RedirectToAction("ListarReservaDeLiquidez");
            }
            catch (Exception ex)
            {
                // Bitácora: Error
                _agregarBitacoraLN.Ejecutar(
                    tabla: "ReservaDeLiquidez",
                    tipoEvento: "Error",
                    ex: ex
                );

                ModelState.AddModelError("", "Ocurrió un error al registrar la reserva.");
                CargarListasEnViewBag();
                return View(model);
            }
        }

        private void CargarListasEnViewBag()
        {
            // Entidades
            var entidades = _listarEntidad.Listar();
            ViewBag.ListaEntidades = new SelectList(
                entidades,
                "IdEntidad",
                "NombreEntidad"
            );

            // Meses
            var periodos = new[]
            {
            new { Value = 1, Text = "Enero" },
            new { Value = 4, Text = "Abril" },
            new { Value = 8, Text = "Agosto" }
        };
            ViewBag.ListaPeriodos = new SelectList(
                periodos, "Value", "Text");

            // Años 2023–2030
            var anios = Enumerable.Range(2023, 8)
                                  .Select(y => new { Value = y, Text = y.ToString() });
            ViewBag.ListaAnios = new SelectList(
                anios, "Value", "Text");
        }

        // GET: ReservaDeLiquidez/Edit/5
        public ActionResult EditarReservaDeLiquidez(int id)
        {
            var reserva = _listarReservaDeLiquidezLN
                            .ListarReservaDeLiquidez()
                            .FirstOrDefault(r => r.IdReservaLiquidez == id);
            if (reserva == null)
                return HttpNotFound();

            reserva.FechaDeModificacion = DateTime.Now;

            return View(reserva);
        }

        // POST: ReservaDeLiquidez/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarReservaDeLiquidez(int id, ReservaDeLiquidezDto model)
        {
            try
            {
                if (id != model.IdReservaLiquidez)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var antes = _listarReservaDeLiquidezLN
                                .ListarReservaDeLiquidez()
                                .FirstOrDefault(r => r.IdReservaLiquidez == id);

                model.FechaDeModificacion = DateTime.Now;

                await _editarReservaDeLiquidezLN.EditarReservaDeLiquidez(model);


                var reglas = await new QueryReglasLN()
                .Evaluar(model, new ObtenerEntidadPorIdLN().Obtener(model.IdEntidad).idTipoEntidad);

                var alertaDto = new ModuloAlertasDto
                {
                    IdEntidad = model.IdEntidad,
                    IdContador = model.IdContador,
                    Periodo = model.Periodo.ToString("MMMM yyyy"),
                    CantidadDeReglasIncumplidas = reglas.Count,
                    IdReservaLiquidez = model.IdReservaLiquidez,
                    FechaDeRegistro = DateTime.Now,
                    FechaDeModificacion = DateTime.Now,
                    Estado = reglas.Any()
                };

                // Crea o actualiza según exista
                await _editarAlertasLN.CrearOActualizarAlertaAsync(alertaDto);
                // Bitácora: Agregar Alerta
                _agregarBitacoraLN.Ejecutar(
                    tabla: "Alerta",
                    tipoEvento: "Editar",
                    datosAnteriores: alertaDto
                );

                // Bitácora: Editar
                _agregarBitacoraLN.Ejecutar(
                    tabla: "ReservaDeLiquidez",
                    tipoEvento: "Editar",
                    datosAnteriores: antes,
                    datosPosteriores: model
                );

                TempData["Success"] = "Reserva de liquidez actualizada correctamente.";
                return RedirectToAction("ListarReservaDeLiquidez");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al actualizar la reserva.");
                // Bitácora: Error
                _agregarBitacoraLN.Ejecutar(
                    tabla: "ReservaDeLiquidez",
                    tipoEvento: "Error",
                    ex: ex
                );
                return View(model);
            }
        }


        // POST: ReservaDeLiquidez/ToggleEstado/5
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
