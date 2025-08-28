using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Modelos
{
    [Table("ReservaLiquidez")]
    public class ReservaDeLiquidezAD
    {
        [Key]
        [Column("IdReservaLiquidez")]
        public int idReservaLiquidez { get; set; }

        [Column("IdEntidad")]
        public int idEntidad { get; set; }

        [Column("MotoDeReserva")]
        public decimal montoDeReserva { get; set; }

        [Column("CantidadDeBeneficiarios")]
        public int cantidadDeBeneficiarios { get; set; }

        [Column("MontoDeSeguroBancario")]
        public decimal montoDeSeguroBancario { get; set; }

        [Column("Periodo")]
        [Required]
        public DateTime periodo { get; set; }

        [Column("IdContador")]
        public int idContador { get; set; }

        [Column("FechaDeRegistro")]
        public DateTime fechaDeRegistro { get; set; }

        [Column("FechaDeModificacion")]
        public DateTime fechaDeModificacion { get; set; }

        [Column("Estado")]
        public int estado { get; set; }

        // (Foreign Keys)
        [ForeignKey("idEntidad")]
        public EntidadAD entidad { get; set; }

        [ForeignKey("idContador")]
        public ContadoresAD contador { get; set; }
    }
}
