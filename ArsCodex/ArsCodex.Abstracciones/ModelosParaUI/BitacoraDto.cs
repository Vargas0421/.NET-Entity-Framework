using System;
using System.ComponentModel.DataAnnotations;

namespace ArsCodex.Abstracciones.ModelosParaUI
{
    public class BitacoraDto
    {
        public int IdEvento { get; set; }
        [Display(Name = "Tabla del Evento")]
        [Required]
        [MinLength(1)]
        public string TablaDeEvento { get; set; }
        [Display(Name = "Tipo de Evento")]
        [Required]
        [MinLength(1)]
        public string TipoDeEvento { get; set; }
        [Display(Name = "Fecha del Evento")]
        public DateTime FechaDeEvento { get; set; }
        [Display(Name = "Descripción del Evento")]
        [Required]
        public string DescripcionDeEvento { get; set; }
        [Display(Name = "StackTrace")]
        [Required]
        public string StackTrace { get; set; }
        [Display(Name = "Datos Anteriores")]
        public string DatosAnteriores { get; set; }
        [Display(Name = "Datos Posteriores")]
        public string DatosPosteriores { get; set; }
    }
}
