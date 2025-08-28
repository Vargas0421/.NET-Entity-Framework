using ArsCodex.Abstracciones.ModelosParaLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.Comunes.ManejoDeErrores
{
    public interface IEventViewerLogger
    {
        void Log(string message, LogType type);
    }
}
