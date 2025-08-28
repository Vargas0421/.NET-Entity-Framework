using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos.Modelos
{
    [Table("Entidad")]
    public class EntidadAD
    {
        [Key]
        [Column("IdEntidad")]
        public int idEntidad { get; set; }

        [Column("CodigoEntidad")]
        [StringLength(30)]
        public string codigoEntidad { get; set; }

        [Column("NombreEntidad")]
        [StringLength(100)]
        public string nombreEntidad { get; set; }

        [Column("TelefonoEntidad")]
        [StringLength(50)]
        public string telefonoEntidad { get; set; }

        [Column("CorreoElectronico")]
        [StringLength(100)]
        public string correoElectronico { get; set; }

        [Column("Direccion")]
        [StringLength(400)]
        public string direccion { get; set; }

        [Column("FechaDeRegistro")]
        public DateTime fechaDeRegistro { get; set; }

        [Column("FechaDeModificacion")]
        public DateTime fechaDeModificacion { get; set; }

        [Column("IdTipoEntidad")]
        public int idTipoEntidad { get; set; }

        [Column("Estado")]
        public bool estado { get; set; }

        // Este es el FK
        [ForeignKey("idTipoEntidad")]
        public TipoDeEntidadesAD tipoEntidad { get; set; }
    }

}

