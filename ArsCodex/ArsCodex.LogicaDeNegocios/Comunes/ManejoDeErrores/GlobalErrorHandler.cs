using ArsCodex.Abstracciones.Comunes.ManejoDeErrores;
using ArsCodex.Abstracciones.ModelosParaLN;
using ArsCodex.LogicaDeNegocios.Comunes.ManejoDeErrores.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ArsCodex.LogicaDeNegocios.Comunes.ManejoDeErrores
{
    public class GlobalErrorHandler
    {
        private readonly IEventViewerLogger _logger;

        public GlobalErrorHandler()
        {
            _logger = LoggerFactory.CreateLogger(); // Usar la fábrica para crear el logger según la configuración
        }
        public void HandleError(HttpContext context, Exception ex)
        {
            string mensajeErrror = $"URL: {context.Request.Url}\nExcepción: {ex.Message}\nStack Trace: {ex.StackTrace}";
            //crearBitacora.Crear();
            _logger.Log(mensajeErrror, LogType.Error);
        }
    }
}
