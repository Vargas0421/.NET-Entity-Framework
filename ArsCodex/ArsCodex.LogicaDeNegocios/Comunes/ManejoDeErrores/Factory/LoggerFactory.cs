using ArsCodex.Abstracciones.Comunes.ManejoDeErrores;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.LogicaDeNegocios.Comunes.ManejoDeErrores.Factory
{
    public static class LoggerFactory // aca se crea el logger, se puede usar para crear diferentes tipos de loggers en el futuro, como por ejemplo: archivo, base de datos, etc.
                                      //basicamente es un patron de diseño que permite crear objetos sin especificar la clase exacta del objeto que se va a crear
                                      // por si se necesita cambiar el tipo de logger en el futuro, solo se cambia la configuracion y no se toca el codigo
    {
        public static IEventViewerLogger CreateLogger()
        {

            string loggerType = ConfigurationManager.AppSettings["LoggerType"];
            switch(loggerType)
            {
                case "event":
                    { return new EventViewerLogger(); }
                case "file":
                    // Aquí podrías agregar una implementación para un logger de archivo si lo necesitas
                    throw new NotImplementedException("File logger is not implemented yet.");
                case"database":
                    // Aquí podrías agregar una implementación para un logger de base de datos si lo necesitas
                    throw new NotImplementedException("Database logger is not implemented yet.");
            }
            return new EventViewerLogger();
        }
    }
}
