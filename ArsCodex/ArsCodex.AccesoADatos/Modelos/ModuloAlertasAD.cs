using ArsCodex.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Modelos
{
        [Table("Alerta")]
        public class ModuloAlertasAD
        {
        [Key]
        public int IdAlerta { get; set; }

        [Required]
        public int IdEntidad { get; set; }

        [Required]
        public int IdContador { get; set; }

        [Required]
        public string Periodo { get; set; }

        [Required]
        public int CantidadDeReglasIncumplidas { get; set; }

        [Required]
        public int IdReservaLiquidez { get; set; }

        [Required]
        public DateTime FechaDeRegistro { get; set; }

        [Required]
        public DateTime FechaDeModificacion { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
