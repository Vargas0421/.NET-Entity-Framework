using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Modelos
{
    [Table("Regla")]
    public class ReglaAD
    {
        [Key]
        [Column("IdRegla")]
        public int IdRegla { get; set; }

        [Column("Nombre")]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Column("Descripcion")]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [Column("Valor")]
        [Required]
        public decimal Valor { get; set; }

        [Column("TipoDeAccion")]
        [Required]
        public int TipoDeAccion { get; set; } // 1 = min, 2 = max

        [Column("FechaDeRegistro")]
        public DateTime FechaDeRegistro { get; set; }

        [Column("FechaDeModificacion")]
        public DateTime? FechaDeModificacion { get; set; }

        [Column("IdTipoEntidad")]
        public int IdTipoEntidad { get; set; }

        [Column("Estado")]
        public bool Estado { get; set; }

        // Llave foránea
        [ForeignKey("IdTipoEntidad")]
        public TipoDeEntidadesAD TipoEntidad { get; set; }
    }
}