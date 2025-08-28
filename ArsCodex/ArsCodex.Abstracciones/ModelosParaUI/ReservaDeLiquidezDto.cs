using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.ModelosParaUI
{
    public class ReservaDeLiquidezDto
    {
        public int IdReservaLiquidez { get; set; }

        [Required]
        [Display(Name = "Entidad")]
        public int IdEntidad { get; set; }
        [Required]
        [Display(Name = "Monto de Reserva")]
        public decimal MontoDeReserva { get; set; }
        [Required]
        [Display(Name = "Cantidad de Beneficiarios")]
        public int CantidadDeBeneficiarios { get; set; }
        [Required]
        [Display(Name = "Monto de Seguro Bancario")]
        public decimal MontoDeSeguroBancario { get; set; }
        [Required]
        [Display(Name = "Período")]
        public DateTime Periodo { get; set; }
        [Required]
        [Display(Name = "Contador")]
        public int IdContador { get; set; }
        [Display(Name = "Fecha de Registro")]
        public DateTime FechaDeRegistro { get; set; }
        [Display(Name = "Fecha de Modificación")]
        public DateTime FechaDeModificacion { get; set; }
        [Display(Name = "Estado")]
        public int Estado { get; set; }
        [Display(Name = "Mes de periodo")]
        [Required(ErrorMessage = "El mes es obligatorio.")]
        [Range(1, 12, ErrorMessage = "Seleccione un mes válido.")]
        public int? PeriodoMes { get; set; }

        [Display(Name = "Año de periodo")]
        [Required(ErrorMessage = "El año es obligatorio.")]
        [Range(2023, 2030, ErrorMessage = "Seleccione un año entre 2023 y 2030.")]
        public int? PeriodoAnio { get; set; }
        public string NombreEntidad { get; set; }
        public string NombreContador { get; set; }
    }
}
