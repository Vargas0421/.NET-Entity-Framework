using ArsCodex.Abstracciones.LogicasDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.AgregarContadores;
using ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.EditarContadores;
using ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.ListarContadores;
using ArsCodex.Abstracciones.LogicasDeNegocios.Contadores.ObtenerContadoresPorId;
using ArsCodex.Abstracciones.ModelosParaUI;
using ArsCodex.AccesoADatos.Modelos;
using ArsCodex.AccesoADatos.TipoDeEntidades.ObtenerTipoDeEntidades;
using ArsCodex.LogicaDeNegocios.Bitacora.AgregarBitacora;
using ArsCodex.LogicaDeNegocios.Contadores.AgregarContadores;
using ArsCodex.LogicaDeNegocios.Contadores.EditarContadores;
using ArsCodex.LogicaDeNegocios.Contadores.ListarContadores;
using ArsCodex.LogicaDeNegocios.Contadores.ObtenerContadoresPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArsCodex.UI.Controllers
{
    public class ContadoresController : Controller
    {
        private readonly IAgregarContadoresLN _agregarContadoresLN;
        private readonly IListarContadoresLN _listarContadoresLN;
        private readonly IObtenerContadoresPorIdLN _obtenerContadoresPorIdLN;
        private readonly IEditarContadoresLN _editarContadoresLN;
        private readonly IAgregarBitacoraLN _agregarBitacoraLN;
        public ContadoresController()
        {
            _agregarContadoresLN = new AgregarContadoresLN();
            _listarContadoresLN = new ListarContadoresLN();
            _obtenerContadoresPorIdLN = new ObtenerContadoresPorIdLN();
            _editarContadoresLN = new EditarContadoresLN();
            _agregarBitacoraLN = new AgregarBitacoraLN();

        }

        [Authorize(Roles = "Administrador")]

        // GET: Contadores
        public ActionResult ListarContadores()
        {
            List<ContadoresDto> listaDeContadores = _listarContadoresLN.ListarContadores();
            return View(listaDeContadores);
        }

        // GET: Contadores/Details/5
        public ActionResult DetalledContadores(int id)
        {
            return View();
        }

        // GET: Contadores/Create
        public ActionResult AgregarContadores()
        {
            var metodosDeContacto = new List<object>
            {
                new { IdMetodo = 1, NombreMetodo = "Llamada" },
                new { IdMetodo = 2, NombreMetodo = "Mensaje de texto" },
                new { IdMetodo = 3, NombreMetodo = "Correo electrónico" },
                new { IdMetodo = 4, NombreMetodo = "Whatsapp" }
            };
            ViewBag.ListaMetodos = new SelectList(metodosDeContacto, "IdMetodo", "NombreMetodo");
            return View();
        }

        // POST: Contadores/Create
        [HttpPost]
        public async Task<ActionResult> AgregarContadores(ContadoresDto elContadorAGuardar)
        {
            try {
            
                elContadorAGuardar.FechaDeRegistro = DateTime.Now;
                int cantidadDeDatosAlmacenados = await _agregarContadoresLN.AgregarContadores(elContadorAGuardar);
                _agregarBitacoraLN.Ejecutar(
                    tabla: "Contador",
                    tipoEvento: "Registrar",
                    datosAnteriores: elContadorAGuardar
                );
                return RedirectToAction("ListarContadores");
            }
            catch (Exception ex)
            {
                _agregarBitacoraLN.Ejecutar(
                tabla: "Contador",
                tipoEvento: "Error",
                ex: ex
                );
                return View();
            }
        }

        // GET: Contadores/Edit/5
        public ActionResult EditarContadores(int id)
        {
            ContadoresDto elContadorAEditar = _obtenerContadoresPorIdLN.obtenerContadorPorId(id);
            var metodosDeContacto = new List<object>
            {
                new { IdMetodo = 1, NombreMetodo = "Llamada" },
                new { IdMetodo = 2, NombreMetodo = "Mensaje de texto" },
                new { IdMetodo = 3, NombreMetodo = "Correo electrónico" },
                new { IdMetodo = 4, NombreMetodo = "Whatsapp" }
            };
            ViewBag.ListaMetodos = new SelectList(metodosDeContacto, "IdMetodo", "NombreMetodo",elContadorAEditar.MetodoDeContacto);
            return View(elContadorAEditar);
        }

        // POST: Contadores/Edit/5
        [HttpPost]
        public ActionResult EditarContadores(ContadoresDto contador)
        {
            if (!ModelState.IsValid)
            {
                return View("ListarContadores", contador);
            }
            try
            {
                // TODO: Add update logic here
                var entidadAntes = new ObtenerTipoDeEntidadesPorIdAD().Obtener(contador.IdContador);

                contador.FechaDeModificacion = DateTime.Now;
                _editarContadoresLN.EditarContadores(contador);
                _agregarBitacoraLN.Ejecutar(
                    tabla: "Contador",
                    tipoEvento: "Editar",
                    datosAnteriores: entidadAntes,
                    datosPosteriores: contador
                );
                return RedirectToAction("ListarContadores");
            }
            catch (Exception ex)
            {
                _agregarBitacoraLN.Ejecutar(
                tabla: "Contador",
                tipoEvento: "Error",
                ex: ex
                );
                return View();
            }
        }

        // GET: Contadores/Delete/5
        public ActionResult EliminarContadores(int id)
        {
            return View();
        }

        // POST: Contadores/Delete/5
        [HttpPost]
        public ActionResult EliminarContadores(int id, FormCollection collection)
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
