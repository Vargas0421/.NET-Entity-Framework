using ArsCodex.Abstracciones.LogicasDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.Abstracciones.LogicasDeNegocios.ModuloAlertas.ListarModuloAlertas;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.LogicaDeNegocios.Entidad.ObtenerEntidadPorId;
using ArsCodex.LogicaDeNegocios.ModuloAlertas.ListarModuloAlertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArsCodex.UI.Controllers
{
    public class ModuloAlertasController : Controller
    {
        private readonly IListarModuloAlertasLN _listarAlertasLN;
        private readonly IObtenerEntidadPorIdLN _obtenerEntidadPorIdLN;
        public ModuloAlertasController()
        {
            _listarAlertasLN = new ListarModuloAlertasLN();
            _obtenerEntidadPorIdLN = new ObtenerEntidadPorIdLN();
        }

        // GET: ModuloAlertas
        public ActionResult ListarModuloAlertas()
        {
            List<ModuloAlertasDto> alertas = _listarAlertasLN.ListarAlertas();

            return View(alertas);
        }

        // GET: ModuloAlertas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModuloAlertas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModuloAlertas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ModuloAlertas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModuloAlertas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ModuloAlertas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModuloAlertas/Delete/5
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
