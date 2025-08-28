using System;
using ArsCodex.AccesoADatos.Modelos;

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArsCodex.AccesoADatos
{
    public class Contexto : DbContext
    {
        public Contexto()
        {
            Database.SetInitializer<Contexto>(null);
        }

        public DbSet<EntidadAD> Entidad { get; set; }
        public DbSet<TipoDeEntidadesAD> TipoDeEntidades { get; set; }

        public DbSet<BitacoraAD> Bitacoras { get; set; }

        public DbSet<ContadoresAD> Contadores { get; set; }

        public DbSet<ReglaAD> Reglas { get; set; }

        public DbSet<ReservaDeLiquidezAD> ReservaDeLiquidez{ get; set; }

        public DbSet<ModuloAlertasAD> ModuloAlertas { get; set; }

    }
}
