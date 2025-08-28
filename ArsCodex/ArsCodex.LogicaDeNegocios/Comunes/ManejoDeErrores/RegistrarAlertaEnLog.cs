using ArsCodex.Abstracciones.Comunes.ManejoDeErrores;
using ArsCodex.Abstracciones.ModelosParaLN;
using ArsCodex.LogicaDeNegocios.Comunes.ManejoDeErrores.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ArsCodex.LogicaDeNegocios.Comunes.ManejoDeErrores
{
    public class RegistrarAlertaEnLog
    {
        private readonly IEventViewerLogger _logger;

        public RegistrarAlertaEnLog()
        {
            _logger = LoggerFactory.CreateLogger(); // Usar la fábrica para crear el logger según la configuración
        }

        public void registrarAlerta(HttpContext context, string mensaje)
        {
            string mensajeAlerta = $"URL: {context.Request.Url}\nMensaje: {mensaje}";
            _logger.Log(mensaje, LogType.Warning);
        }
    }
}
