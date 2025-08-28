using ArsCodex.Abstracciones.Comunes.ManejoDeErrores;
using ArsCodex.Abstracciones.ModelosParaLN;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace ArsCodex.LogicaDeNegocios.Comunes.ManejoDeErrores
    {

        public class EventViewerLogger : IEventViewerLogger
    {
            private const string SourceName = "ArsCodexSource";
            private const string LogName = "ArsCodexLog";

            public EventViewerLogger()
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }
            }

            public void Log(string message, LogType type)
            {
                try
                {
                    EventLogEntryType entryType = EventLogEntryType.Information;

                if (type == LogType.Info) entryType = EventLogEntryType.Information; // esto determina el timpo de simbolo que se usará en el visor de eventos
                if (type == LogType.Warning) entryType = EventLogEntryType.Warning;
                if (type == LogType.Error) entryType = EventLogEntryType.Error;
                EventLog.WriteEntry(SourceName, message, entryType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al registrar el evento: {ex.Message}");
                }
            }
        }
    }