using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Modelos
{
    [Table("TipoEntidad")]
    public class TipoDeEntidadesAD
    {
        [Key]
        [Column("IdTipoEntidad")]
        public int idTipoEntidad { get; set; }
   
        [Column("NombreTipoEntidad")]
        public string nombreTipoEntidad { get; set; }

        [Column("Descripcion")]
        public string descripcion { get; set; }

        [Column("FechaDeRegistro")]
        public DateTime fechaDeRegistro { get; set; }

        [Column("FechaDeModificacion")]
        public DateTime? fechaDeModificacion { get; set; }

        [Column("Estado")]
        public bool estado { get; set; }

    }
}
