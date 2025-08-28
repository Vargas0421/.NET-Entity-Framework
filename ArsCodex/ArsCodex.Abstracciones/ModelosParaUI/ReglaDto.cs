using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.ModelosParaUI
{
    public class ReglaDto
    {
        public int IdRegla { get; set; }


        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [MinLength(10)]
        [MaxLength(100)]
        [Display(Name = "Descripción")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Valor")]
        [Range(0, double.MaxValue)]
        [Required]
        public decimal Valor { get; set; }

        [Display(Name = "Tipo de Acción")]
        [Required]
        [Range(1, 2, ErrorMessage = "Debe ser 1 (mínimo) o 2 (máximo)")]
        public int TipoDeAccion { get; set; } // 1 = min, 2 = max

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaDeRegistro { get; set; }

        [Display(Name = "Fecha de Modificación")]
        public DateTime? FechaDeModificacion { get; set; }

        [Required]
        public int IdTipoEntidad { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
    }
}
    
