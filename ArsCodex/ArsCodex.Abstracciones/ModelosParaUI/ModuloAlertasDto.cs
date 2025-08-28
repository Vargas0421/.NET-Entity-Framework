using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.ModelosParaUI
{
    public class ModuloAlertasDto
    {
        public int IdAlerta { get; set; }

        public int IdEntidad { get; set; }

        [Display(Name = "Nombre de la Entidad")]
        public string NombreDeLaEntidad { get; set; }

        public int IdContador { get; set; }

        [Display(Name = "Nombre del Contador")]
        public string NombreDelContador { get; set; }

        public string Periodo { get; set; }

        [Display(Name = "Cantidad de Reglas Incumplidas")]
        public int CantidadDeReglasIncumplidas { get; set; }

        [Display(Name = "ID Reserva de Liquidez")]
        public int IdReservaLiquidez { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación")]
        public DateTime FechaDeModificacion { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
    }
}
