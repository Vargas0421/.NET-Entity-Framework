using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.ModelosParaUI
{
    public class EntidadDto
    {
        public int idEntidad { get; set; }

        [MinLength(4)]
        [Display(Name = "Código")]
        [Required]
        public string codigoEntidad { get; set; }
        [MinLength(5)]
        [Display(Name = "Nombre")]
        [Required]
        public string nombreEntidad { get; set; }
        [MinLength(5)]
        [Display(Name = "Teléfono")]
        [Required]
        public string telefonoEntidad { get; set; }
        [MinLength(8)]
        [Display(Name = "Correo Electrónico")]
        [Required]
        public string correoElectronico { get; set; }
        [MinLength(15)]
        [Display(Name = "Dirección")]
        [Required]
        public string direccion { get; set; }
        [Display(Name = "Fecha De registro")]
        public DateTime? fechaDeRegistro { get; set; }
        [Display(Name = "Fecha De Modificación")]
        public DateTime? fechaDeModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        public int idTipoEntidad { get; set; }
        [Display(Name = "Tipo entidad")]
        public string NombreTipoEntidad { get; set; }
    }
}
