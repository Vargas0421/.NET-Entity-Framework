using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.ModelosParaUI
{
    public class TipoDeEntidadesDto
    {
        public int IdTipoEntidad { get; set; }
        [Display(Name = "Tipo entidad")]
        [Required]
        public string NombreTipoEntidad { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        public string Descripcion { get; set; }
        [Display(Name = "Fecha de registro")]
        public DateTime FechaDeRegistro { get; set; }
        [Display(Name = "Fecha de modificación")]
        public DateTime? FechaDeModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool Estado { get; set; }
    }
}