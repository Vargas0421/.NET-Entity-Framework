using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.Abstracciones.ModelosParaUI
{
    public class ContadoresDto
    {

        public int IdContador { get; set; }

        public Guid? IdContadorIdentity { get; set; } // el tipo Guid es para manejar identificadores únicos globales

        [Required]
        [Display(Name = "Identificación")]
        public string IdentificacionContador { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NombreContador { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellidoContador { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellidoContador { get; set; }

        [Required]
        [Display(Name = "Número de Colegio")]
        public string NumeroDeColegio { get; set; }

        [Required]
        [Display(Name = "Correo electrónico")]
        public string CorreoElectronico { get; set; }

        [Required]
        [Display(Name = "Teléfono celular")]
        public string TelefonoCelular { get; set; }

        [Required]
        [Display(Name = "Teléfono secundario")]
        public string TelefonoSecundario { get; set; }

        [Required]
        [Display(Name = "Método de contacto")] // (1 – Llamada, 2 – Mensaje de texto, 3 – Correo electrónico, 4 – Whatsapp)
        public int MetodoDeContacto { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime FechaDeRegistro { get; set; }

        public DateTime? FechaDeModificacion { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; } // "Activo" o "Inactivo"



    }
}
